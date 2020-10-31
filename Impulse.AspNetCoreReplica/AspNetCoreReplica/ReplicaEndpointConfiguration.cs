using System;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using Microsoft.Extensions.Configuration;

namespace Impulse.Web.AspNetCoreReplica
{
    /// <summary>
    /// https://github.com/dotnet/aspnetcore/blob/0c2ee920a17fc11ecc6b5fe8febe330262a2d69b/src/Servers/Kestrel/Core/src/EndpointConfiguration.cs
    /// </summary>
    public class ReplicaEndpointConfiguration
    {
        internal ReplicaEndpointConfiguration(bool isHttps, ReplicaListenOptions listenOptions, HttpsConnectionAdapterOptions httpsOptions, IConfigurationSection configSection)
        {
            IsHttps = isHttps;
            ListenOptions = listenOptions ?? throw new ArgumentNullException(nameof(listenOptions));
            HttpsOptions = httpsOptions ?? throw new ArgumentNullException(nameof(httpsOptions));
            ConfigSection = configSection ?? throw new ArgumentNullException(nameof(configSection));
        }

        public bool IsHttps { get; }
        public ReplicaListenOptions ListenOptions { get; }
        public HttpsConnectionAdapterOptions HttpsOptions { get; }
        public IConfigurationSection ConfigSection { get; }
    }
}
