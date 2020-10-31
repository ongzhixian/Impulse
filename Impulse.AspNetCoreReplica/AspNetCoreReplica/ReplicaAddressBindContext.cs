using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Impulse.Web.AspNetCoreReplica
{
    /// <summary>
    /// https://github.com/dotnet/aspnetcore/blob/0c2ee920a17fc11ecc6b5fe8febe330262a2d69b/src/Servers/Kestrel/Core/src/Internal/AddressBindContext.cs
    /// </summary>
    internal class ReplicaAddressBindContext
    {
        public ICollection<string> Addresses { get; set; }
        public List<ReplicaListenOptions> ListenOptions { get; set; }
        public ReplicaKestrelServerOptions ServerOptions { get; set; }
        public ILogger Logger { get; set; }

        public Func<ReplicaListenOptions, Task> CreateBinding { get; set; }
    }
}
