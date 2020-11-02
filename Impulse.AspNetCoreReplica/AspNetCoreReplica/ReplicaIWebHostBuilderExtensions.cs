using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Abstractions.Internal;
using Microsoft.AspNetCore.Server.Kestrel.Transport.Sockets;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Options;
using System;

namespace Impulse.Web.AspNetCoreReplica
{
    /// <summary>
    /// https://github.com/dotnet/aspnetcore/blob/0c2ee920a17fc11ecc6b5fe8febe330262a2d69b/src/Servers/Kestrel/Kestrel/src/WebHostBuilderKestrelExtensions.cs
    /// </summary>
    public static class ReplicaIWebHostBuilderExtensions
    {
        public static IWebHostBuilder ReplicaUseKestrel(this IWebHostBuilder hostBuilder)
        {
            return hostBuilder.ConfigureServices(services =>
            {
                // Don't override an already-configured transport
                services.TryAddSingleton<ITransportFactory, SocketTransportFactory>();

                services.AddTransient<IConfigureOptions<ReplicaKestrelServerOptions>, ReplicaKestrelServerOptionsSetup>();

                services.AddSingleton<IServer, KestrelServer>();
            });
        }

        public static IWebHostBuilder ReplicaUseKestrel(this IWebHostBuilder hostBuilder, Action<KestrelServerOptions> options)
        {
            return hostBuilder.ReplicaUseKestrel().ConfigureKestrel(options);
        }

        public static IWebHostBuilder ReplicaUseKestrel(this IWebHostBuilder hostBuilder, Action<WebHostBuilderContext, ReplicaKestrelServerOptions> configureOptions)
        {
            return hostBuilder.ReplicaUseKestrel().ConfigureKestrel(configureOptions);
        }

        public static IWebHostBuilder ReplicaUseKestrel(this IWebHostBuilder hostBuilder, Action<WebHostBuilderContext, ReplicaKestrelServerOptions> configureOptions, IConfiguration kestrelConfiguration)
        {
            
            return hostBuilder.ReplicaUseKestrel().ConfigureKestrel(configureOptions);
        }

        public static IWebHostBuilder ConfigureKestrel(this IWebHostBuilder hostBuilder, Action<ReplicaKestrelServerOptions> options)
        {
            return hostBuilder.ConfigureServices(services =>
            {
                services.Configure(options);
            });
        }

        public static IWebHostBuilder ConfigureKestrel(this IWebHostBuilder hostBuilder, Action<WebHostBuilderContext, ReplicaKestrelServerOptions> configureOptions)
        {
            if (configureOptions == null)
            {
                throw new ArgumentNullException(nameof(configureOptions));
            }

            return hostBuilder.ConfigureServices((context, services) =>
            {
                services.Configure<ReplicaKestrelServerOptions>(options =>
                {
                    configureOptions(context, options);
                });
            });
        }

    }
}