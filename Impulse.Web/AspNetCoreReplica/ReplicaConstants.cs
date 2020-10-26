using System;

namespace Impulse.Web.AspNetCoreReplica
{
    /// <summary>
    /// https://github.com/dotnet/aspnetcore/blob/0c2ee920a17fc11ecc6b5fe8febe330262a2d69b/src/Servers/Kestrel/Core/src/Internal/Infrastructure/Constants.cs
    /// </summary>
    internal static class ReplicaConstants
    {
        public const int MaxExceptionDetailSize = 128;

        /// <summary>
        /// The endpoint Kestrel will bind to if nothing else is specified.
        /// </summary>
        public static readonly string DefaultServerAddress = "http://localhost:5000";

        /// <summary>
        /// The endpoint Kestrel will bind to if nothing else is specified and a default certificate is available.
        /// </summary>
        public static readonly string DefaultServerHttpsAddress = "https://localhost:5001";

        /// <summary>
        /// Prefix of host name used to specify Unix sockets in the configuration.
        /// </summary>
        public const string UnixPipeHostPrefix = "unix:/";

        /// <summary>
        /// Prefix of host name used to specify pipe file descriptor in the configuration.
        /// </summary>
        public const string PipeDescriptorPrefix = "pipefd:";

        /// <summary>
        /// Prefix of host name used to specify socket descriptor in the configuration.
        /// </summary>
        public const string SocketDescriptorPrefix = "sockfd:";

        public const string ServerName = "Kestrel";

        public static readonly TimeSpan RequestBodyDrainTimeout = TimeSpan.FromSeconds(5);

        public static readonly ArraySegment<byte> EmptyData = new ArraySegment<byte>(new byte[0]);
    }
}
