using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Core.Adapter.Internal;
using Microsoft.Extensions.Logging;

namespace Impulse.Web.AspNetCoreReplica
{
    public class ReplicaLoggingConnectionAdapter : IConnectionAdapter
    {
        private readonly ILogger _logger;

        public ReplicaLoggingConnectionAdapter(ILogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }

            _logger = logger;
        }

        public bool IsHttps => false;

        public Task<IAdaptedConnection> OnConnectionAsync(ConnectionAdapterContext context)
        {
            return Task.FromResult<IAdaptedConnection>(
                new LoggingAdaptedConnection(context.ConnectionStream, _logger));
        }

        private class LoggingAdaptedConnection : IAdaptedConnection
        {
            public LoggingAdaptedConnection(Stream rawStream, ILogger logger)
            {
                ConnectionStream = new ReplicaLoggingStream(rawStream, logger);
            }

            public Stream ConnectionStream { get; }

            public void Dispose()
            {
            }
        }
    }
}
