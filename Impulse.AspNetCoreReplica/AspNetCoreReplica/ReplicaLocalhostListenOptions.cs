using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal;
using Microsoft.Extensions.Logging;

namespace Impulse.Web.AspNetCoreReplica
{
    /// <summary>
    /// https://github.com/dotnet/aspnetcore/blob/0c2ee920a17fc11ecc6b5fe8febe330262a2d69b/src/Servers/Kestrel/Core/src/LocalhostListenOptions.cs
    /// </summary>
    internal class ReplicaLocalhostListenOptions : ReplicaListenOptions
    {
        internal ReplicaLocalhostListenOptions(int port)
            : base(new IPEndPoint(IPAddress.Loopback, port))
        {
            if (port == 0)
            {
                throw new InvalidOperationException(ReplicaCoreStrings.DynamicPortOnLocalhostNotSupported);
            }
        }

        /// <summary>
        /// Gets the name of this endpoint to display on command-line when the web server starts.
        /// </summary>
        internal override string GetDisplayName()
        {
            var scheme = ConnectionAdapters.Any(f => f.IsHttps)
                ? "https"
                : "http";

            return $"{scheme}://localhost:{IPEndPoint.Port}";
        }

        internal override async Task BindAsync(ReplicaAddressBindContext context)
        {
            var exceptions = new List<Exception>();

            try
            {
                var v4Options = Clone(IPAddress.Loopback);
                await ReplicaAddressBinder.BindEndpointAsync(v4Options, context).ConfigureAwait(false);
            }
            catch (Exception ex) when (!(ex is IOException))
            {
                context.Logger.LogWarning(0, ReplicaCoreStrings.NetworkInterfaceBindingFailed, GetDisplayName(), "IPv4 loopback", ex.Message);
                exceptions.Add(ex);
            }

            try
            {
                var v6Options = Clone(IPAddress.IPv6Loopback);
                await ReplicaAddressBinder.BindEndpointAsync(v6Options, context).ConfigureAwait(false);
            }
            catch (Exception ex) when (!(ex is IOException))
            {
                context.Logger.LogWarning(0, ReplicaCoreStrings.NetworkInterfaceBindingFailed, GetDisplayName(), "IPv6 loopback", ex.Message);
                exceptions.Add(ex);
            }

            if (exceptions.Count == 2)
            {
                throw new IOException(ReplicaCoreStrings.FormatAddressBindingFailed(GetDisplayName()), new AggregateException(exceptions));
            }

            // If StartLocalhost doesn't throw, there is at least one listener.
            // The port cannot change for "localhost".
            context.Addresses.Add(GetDisplayName());
        }

        // used for cloning to two IPEndpoints
        internal ReplicaListenOptions Clone(IPAddress address)
        {
            var options = new ReplicaListenOptions(new IPEndPoint(address, IPEndPoint.Port))
            {
                HandleType = HandleType,
                KestrelServerOptions = KestrelServerOptions,
                NoDelay = NoDelay,
                Protocols = Protocols,
            };

            options._middleware.AddRange(_middleware);
            options.ConnectionAdapters.AddRange(ConnectionAdapters);
            return options;
        }
    }
}
