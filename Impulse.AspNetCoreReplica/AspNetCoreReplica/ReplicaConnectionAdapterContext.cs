using System.IO;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Http.Features;

namespace Impulse.Web.AspNetCoreReplica
{
    /// <summary>
    /// https://github.com/dotnet/aspnetcore/blob/0c2ee920a17fc11ecc6b5fe8febe330262a2d69b/src/Servers/Kestrel/Core/src/Adapter/Internal/ConnectionAdapterContext.cs
    /// </summary>

    public class ReplicaConnectionAdapterContext
    {
        internal ReplicaConnectionAdapterContext(ConnectionContext connectionContext, Stream connectionStream)
        {
            ConnectionContext = connectionContext;
            ConnectionStream = connectionStream;
        }

        internal ConnectionContext ConnectionContext { get; }

        public IFeatureCollection Features => ConnectionContext.Features;

        public Stream ConnectionStream { get; }
    }
}
