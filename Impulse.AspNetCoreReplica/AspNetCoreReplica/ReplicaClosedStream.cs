using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;

namespace Impulse.Web.AspNetCoreReplica
{
    /// <summary>
    /// https://github.com/dotnet/aspnetcore/blob/0c2ee920a17fc11ecc6b5fe8febe330262a2d69b/src/Servers/Kestrel/Core/src/Internal/ClosedStream.cs
    /// </summary>
    internal class ReplicaClosedStream : Stream
    {
        private static readonly Task<int> ZeroResultTask = Task.FromResult(result: 0);

        public override bool CanRead => true;
        public override bool CanSeek => false;
        public override bool CanWrite => false;

        public override long Length
        {
            get
            {
                throw new NotSupportedException();
            }
        }

        public override long Position
        {
            get
            {
                throw new NotSupportedException();
            }
            set
            {
                throw new NotSupportedException();
            }
        }

        public override void Flush()
        {
        }

        public override long Seek(long offset, SeekOrigin origin)
        {
            throw new NotSupportedException();
        }

        public override void SetLength(long value)
        {
            throw new NotSupportedException();
        }

        public override int Read(byte[] buffer, int offset, int count)
        {
            return 0;
        }

        public override Task<int> ReadAsync(byte[] buffer, int offset, int count, CancellationToken cancellationToken)
        {
            return ZeroResultTask;
        }

        public override void Write(byte[] buffer, int offset, int count)
        {
            throw new NotSupportedException();
        }
    }
}
