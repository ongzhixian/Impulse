using System;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Options;

namespace Impulse.Web.AspNetCoreReplica
{
    /// <summary>
    /// ZX: Not sure if we need this; add it in for now
    /// https://github.com/dotnet/aspnetcore/blob/0c2ee920a17fc11ecc6b5fe8febe330262a2d69b/src/Servers/Kestrel/Core/src/Internal/KestrelServerOptionsSetup.cs
    /// </summary>
    public class ReplicaKestrelServerOptionsSetup : IConfigureOptions<ReplicaKestrelServerOptions>
    {
        private IServiceProvider _services;

        public ReplicaKestrelServerOptionsSetup(IServiceProvider services)
        {
            _services = services;
        }

        public void Configure(ReplicaKestrelServerOptions options)
        {
            options.ApplicationServices = _services;
        }
    }
}
