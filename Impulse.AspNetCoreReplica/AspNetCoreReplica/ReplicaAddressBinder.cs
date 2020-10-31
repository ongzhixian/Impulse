using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server.Features;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal.Infrastructure;
using Microsoft.Extensions.Logging;

namespace Impulse.Web.AspNetCoreReplica
{
    internal class ReplicaAddressBinder
    {
        public static async Task BindAsync(IServerAddressesFeature addresses,
            ReplicaKestrelServerOptions serverOptions,
            ILogger logger,
            Func<ReplicaListenOptions, Task> createBinding)
        {
            var listenOptions = serverOptions.ListenOptions;
            var strategy = CreateStrategy(
                listenOptions.ToArray(),
                addresses.Addresses.ToArray(),
                addresses.PreferHostingUrls);

            var context = new ReplicaAddressBindContext
            {
                Addresses = addresses.Addresses,
                ListenOptions = listenOptions,
                ServerOptions = serverOptions,
                Logger = logger,
                CreateBinding = createBinding
            };

            // reset options. The actual used options and addresses will be populated
            // by the address binding feature
            listenOptions.Clear();
            addresses.Addresses.Clear();

            await strategy.BindAsync(context).ConfigureAwait(false);
        }

        private static IStrategy CreateStrategy(ReplicaListenOptions[] listenOptions, string[] addresses, bool preferAddresses)
        {
            var hasListenOptions = listenOptions.Length > 0;
            var hasAddresses = addresses.Length > 0;

            if (preferAddresses && hasAddresses)
            {
                if (hasListenOptions)
                {
                    return new OverrideWithAddressesStrategy(addresses);
                }

                return new AddressesStrategy(addresses);
            }
            else if (hasListenOptions)
            {
                if (hasAddresses)
                {
                    return new OverrideWithEndpointsStrategy(listenOptions, addresses);
                }

                return new EndpointsStrategy(listenOptions);
            }
            else if (hasAddresses)
            {
                // If no endpoints are configured directly using KestrelServerOptions, use those configured via the IServerAddressesFeature.
                return new AddressesStrategy(addresses);
            }
            else
            {
                // "localhost" for both IPv4 and IPv6 can't be represented as an IPEndPoint.
                return new DefaultAddressStrategy();
            }
        }

        /// <summary>
        /// Returns an <see cref="IPEndPoint"/> for the given host an port.
        /// If the host parameter isn't "localhost" or an IP address, use IPAddress.Any.
        /// </summary>
        protected internal static bool TryCreateIPEndPoint(BindingAddress address, out IPEndPoint endpoint)
        {
            if (!IPAddress.TryParse(address.Host, out var ip))
            {
                endpoint = null;
                return false;
            }

            endpoint = new IPEndPoint(ip, address.Port);
            return true;
        }

        internal static async Task BindEndpointAsync(ReplicaListenOptions endpoint, ReplicaAddressBindContext context)
        {
            try
            {
                await context.CreateBinding(endpoint).ConfigureAwait(false);
            }
            catch (AddressInUseException ex)
            {
                throw new IOException(ReplicaCoreStrings.FormatEndpointAlreadyInUse(endpoint), ex);
            }

            context.ListenOptions.Add(endpoint);
        }

        internal static ReplicaListenOptions ParseAddress(string address, out bool https)
        {
            var parsedAddress = BindingAddress.Parse(address);
            https = false;

            if (parsedAddress.Scheme.Equals("https", StringComparison.OrdinalIgnoreCase))
            {
                https = true;
            }
            else if (!parsedAddress.Scheme.Equals("http", StringComparison.OrdinalIgnoreCase))
            {
                throw new InvalidOperationException(ReplicaCoreStrings.FormatUnsupportedAddressScheme(address));
            }

            if (!string.IsNullOrEmpty(parsedAddress.PathBase))
            {
                throw new InvalidOperationException(ReplicaCoreStrings.FormatConfigurePathBaseFromMethodCall($"{nameof(IApplicationBuilder)}.UsePathBase()"));
            }

            ReplicaListenOptions options = null;
            if (parsedAddress.IsUnixPipe)
            {
                options = new ReplicaListenOptions(parsedAddress.UnixPipePath);
            }
            else if (string.Equals(parsedAddress.Host, "localhost", StringComparison.OrdinalIgnoreCase))
            {
                // "localhost" for both IPv4 and IPv6 can't be represented as an IPEndPoint.
                options = new ReplicaLocalhostListenOptions(parsedAddress.Port);
            }
            else if (TryCreateIPEndPoint(parsedAddress, out var endpoint))
            {
                options = new ReplicaListenOptions(endpoint);
            }
            else
            {
                // when address is 'http://hostname:port', 'http://*:port', or 'http://+:port'
                options = new ReplicaAnyIPListenOptions(parsedAddress.Port);
            }

            return options;
        }

        private interface IStrategy
        {
            Task BindAsync(ReplicaAddressBindContext context);
        }

        private class DefaultAddressStrategy : IStrategy
        {
            public async Task BindAsync(ReplicaAddressBindContext context)
            {
                var httpDefault = ParseAddress(ReplicaConstants.DefaultServerAddress, out var https);
                context.ServerOptions.ApplyEndpointDefaults(httpDefault);
                await httpDefault.BindAsync(context).ConfigureAwait(false);

                // Conditional https default, only if a cert is available
                var httpsDefault = ParseAddress(ReplicaConstants.DefaultServerHttpsAddress, out https);
                context.ServerOptions.ApplyEndpointDefaults(httpsDefault);

                if (httpsDefault.ConnectionAdapters.Any(f => f.IsHttps)
                    || httpsDefault.TryUseHttps())
                {
                    await httpsDefault.BindAsync(context).ConfigureAwait(false);
                    context.Logger.LogDebug(ReplicaCoreStrings.BindingToDefaultAddresses,
                        ReplicaConstants.DefaultServerAddress, ReplicaConstants.DefaultServerHttpsAddress);
                }
                else
                {
                    // No default cert is available, do not bind to the https endpoint.
                    context.Logger.LogDebug(ReplicaCoreStrings.BindingToDefaultAddress, ReplicaConstants.DefaultServerAddress);
                }
            }
        }

        private class OverrideWithAddressesStrategy : AddressesStrategy
        {
            public OverrideWithAddressesStrategy(IReadOnlyCollection<string> addresses)
                : base(addresses)
            {
            }

            public override Task BindAsync(ReplicaAddressBindContext context)
            {
                var joined = string.Join(", ", _addresses);
                context.Logger.LogInformation(ReplicaCoreStrings.OverridingWithPreferHostingUrls, nameof(IServerAddressesFeature.PreferHostingUrls), joined);

                return base.BindAsync(context);
            }
        }

        private class OverrideWithEndpointsStrategy : EndpointsStrategy
        {
            private readonly string[] _originalAddresses;

            public OverrideWithEndpointsStrategy(IReadOnlyCollection<ReplicaListenOptions> endpoints, string[] originalAddresses)
                : base(endpoints)
            {
                _originalAddresses = originalAddresses;
            }

            public override Task BindAsync(ReplicaAddressBindContext context)
            {
                var joined = string.Join(", ", _originalAddresses);
                context.Logger.LogWarning(ReplicaCoreStrings.OverridingWithKestrelOptions, joined, "UseKestrel()");

                return base.BindAsync(context);
            }
        }

        private class EndpointsStrategy : IStrategy
        {
            private readonly IReadOnlyCollection<ReplicaListenOptions> _endpoints;

            public EndpointsStrategy(IReadOnlyCollection<ReplicaListenOptions> endpoints)
            {
                _endpoints = endpoints;
            }

            public virtual async Task BindAsync(ReplicaAddressBindContext context)
            {
                foreach (var endpoint in _endpoints)
                {
                    await endpoint.BindAsync(context).ConfigureAwait(false);
                }
            }
        }

        private class AddressesStrategy : IStrategy
        {
            protected readonly IReadOnlyCollection<string> _addresses;

            public AddressesStrategy(IReadOnlyCollection<string> addresses)
            {
                _addresses = addresses;
            }

            public virtual async Task BindAsync(ReplicaAddressBindContext context)
            {
                foreach (var address in _addresses)
                {
                    var options = ParseAddress(address, out var https);
                    context.ServerOptions.ApplyEndpointDefaults(options);

                    if (https && !options.ConnectionAdapters.Any(f => f.IsHttps))
                    {
                        options.UseHttps();
                    }

                    await options.BindAsync(context).ConfigureAwait(false);
                }
            }
        }
    }
}
