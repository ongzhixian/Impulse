using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using Microsoft.AspNetCore.Certificates.Generation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Server.Kestrel;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.AspNetCore.Server.Kestrel.Internal;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Abstractions.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace Impulse.Web.AspNetCoreReplica
{
    /// <summary>
    /// https://github.com/dotnet/aspnetcore/blob/0c2ee920a17fc11ecc6b5fe8febe330262a2d69b/src/Servers/Kestrel/Core/src/KestrelServerOptions.cs
    /// </summary>
    public class ReplicaKestrelServerOptions : KestrelServerOptions
    {
        public ReplicaKestrelServerOptions() : base()
        {
        }

        /// <summary>
        /// Configures the endpoints that Kestrel should listen to.
        /// </summary>
        /// <remarks>
        /// If this list is empty, the server.urls setting (e.g. UseUrls) is used.
        /// </remarks>
        internal List<ReplicaListenOptions> ListenOptions { get; } = new List<ReplicaListenOptions>();


        /// <summary>
        /// Provides a configuration source where endpoints will be loaded from on server start.
        /// The default is null.
        /// </summary>
        public new ReplicaKestrelConfigurationLoader ConfigurationLoader { get; set; }

        /// <summary>
        /// A default configuration action for all endpoints. Use for Listen, configuration, the default url, and URLs.
        /// </summary>
        private Action<ReplicaListenOptions> EndpointDefaults { get; set; } = _ => { };

        /// <summary>
        /// A default configuration action for all https endpoints.
        /// </summary>
        private Action<HttpsConnectionAdapterOptions> HttpsDefaults { get; set; } = _ => { };

        /// <summary>
        /// The default server certificate for https endpoints. This is applied lazily after HttpsDefaults and user options.
        /// </summary>
        internal X509Certificate2 DefaultCertificate { get; set; }

        /// <summary>
        /// Has the default dev certificate load been attempted?
        /// </summary>
        internal bool IsDevCertLoaded { get; set; }

        /// <summary>
        /// Specifies a configuration Action to run for each newly created endpoint. Calling this again will replace
        /// the prior action.
        /// </summary>
        public void ConfigureEndpointDefaults(Action<ReplicaListenOptions> configureOptions)
        {
            EndpointDefaults = configureOptions ?? throw new ArgumentNullException(nameof(configureOptions));
        }

        internal void ApplyEndpointDefaults(ReplicaListenOptions listenOptions)
        {
            listenOptions.KestrelServerOptions = this;
            ConfigurationLoader?.ApplyConfigurationDefaults(listenOptions);
            EndpointDefaults(listenOptions);
        }


        internal void ApplyHttpsDefaults(HttpsConnectionAdapterOptions httpsOptions)
        {
            HttpsDefaults(httpsOptions);
        }

        internal void ApplyDefaultCert(HttpsConnectionAdapterOptions httpsOptions)
        {
            if (httpsOptions.ServerCertificate != null || httpsOptions.ServerCertificateSelector != null)
            {
                return;
            }

            EnsureDefaultCert();

            httpsOptions.ServerCertificate = DefaultCertificate;
        }

        private void EnsureDefaultCert()
        {
            if (DefaultCertificate == null && !IsDevCertLoaded)
            {
                IsDevCertLoaded = true; // Only try once
                var logger = ApplicationServices.GetRequiredService<ILogger<KestrelServer>>();
                try
                {
                    var certificateManager = new ReplicaCertificateManager();
                    DefaultCertificate = certificateManager.ListCertificates(ReplicaCertificatePurpose.HTTPS, StoreName.My, StoreLocation.CurrentUser, isValid: true)
                        .FirstOrDefault();

                    if (DefaultCertificate != null)
                    {
                        logger.LocatedDevelopmentCertificate(DefaultCertificate);
                    }
                    else
                    {
                        logger.UnableToLocateDevelopmentCertificate();
                    }
                }
                catch
                {
                    logger.UnableToLocateDevelopmentCertificate();
                }
            }
        }




        /// <summary>
        /// Bind to given IP address and port.
        /// The callback configures endpoint-specific settings.
        /// </summary>
        public void Listen(IPAddress address, int port, Action<ReplicaListenOptions> configure)
        {
            if (address == null)
            {
                throw new ArgumentNullException(nameof(address));
            }

            Listen(new IPEndPoint(address, port), configure);
        }



        /// <summary>
        /// Bind to given IP address and port.
        /// The callback configures endpoint-specific settings.
        /// </summary>
        public void Listen(IPEndPoint endPoint, Action<ReplicaListenOptions> configure)
        {
            if (endPoint == null)
            {
                throw new ArgumentNullException(nameof(endPoint));
            }
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            var listenOptions = new ReplicaListenOptions(endPoint);
            ApplyEndpointDefaults(listenOptions);
            configure(listenOptions);
            ListenOptions.Add(listenOptions);
        }


        /// <summary>
        /// Listens on ::1 and 127.0.0.1 with the given port. Requesting a dynamic port by specifying 0 is not supported
        /// for this type of endpoint.
        /// </summary>
        public void ListenLocalhost(int port, Action<ReplicaListenOptions> configure)
        {
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            var listenOptions = new ReplicaLocalhostListenOptions(port);
            ApplyEndpointDefaults(listenOptions);
            configure(listenOptions);
            ListenOptions.Add(listenOptions);
        }


        /// <summary>
        /// Listens on all IPs using IPv6 [::], or IPv4 0.0.0.0 if IPv6 is not supported.
        /// </summary>
        public void ListenAnyIP(int port, Action<ReplicaListenOptions> configure)
        {
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            var listenOptions = new ReplicaAnyIPListenOptions(port);
            ApplyEndpointDefaults(listenOptions);
            configure(listenOptions);
            ListenOptions.Add(listenOptions);
        }


        /// <summary>
        /// Bind to given Unix domain socket path.
        /// Specify callback to configure endpoint-specific settings.
        /// </summary>
        public void ListenUnixSocket(string socketPath, Action<ReplicaListenOptions> configure)
        {
            if (socketPath == null)
            {
                throw new ArgumentNullException(nameof(socketPath));
            }
            if (socketPath.Length == 0 || socketPath[0] != '/')
            {
                throw new ArgumentException(ReplicaCoreStrings.UnixSocketPathMustBeAbsolute, nameof(socketPath));
            }
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            var listenOptions = new ReplicaListenOptions(socketPath);
            ApplyEndpointDefaults(listenOptions);
            configure(listenOptions);
            ListenOptions.Add(listenOptions);
        }


        /// <summary>
        /// Open a socket file descriptor.
        /// The callback configures endpoint-specific settings.
        /// </summary>
        public void ListenHandle(ulong handle, Action<ReplicaListenOptions> configure)
        {
            if (configure == null)
            {
                throw new ArgumentNullException(nameof(configure));
            }

            var listenOptions = new ReplicaListenOptions(handle);
            ApplyEndpointDefaults(listenOptions);
            configure(listenOptions);
            ListenOptions.Add(listenOptions);
        }
    }
}
