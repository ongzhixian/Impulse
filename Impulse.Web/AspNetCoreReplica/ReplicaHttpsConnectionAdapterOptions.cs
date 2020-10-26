using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.AspNetCore.Server.Kestrel.Https;
using System;
using System.Security.Authentication;

namespace Impulse.Web.AspNetCoreReplica
{

    /// <summary>
    /// https://github.com/dotnet/aspnetcore/blob/0c2ee920a17fc11ecc6b5fe8febe330262a2d69b/src/Servers/Kestrel/Core/src/HttpsConnectionAdapterOptions.cs
    /// </summary>
    public class ReplicaHttpsConnectionAdapterOptions : HttpsConnectionAdapterOptions
    {
        public ReplicaHttpsConnectionAdapterOptions()
        {
            ClientCertificateMode = ClientCertificateMode.NoCertificate;
            SslProtocols = SslProtocols.Tls12 | SslProtocols.Tls11;
            HandshakeTimeout = TimeSpan.FromSeconds(10);
        }

        /// The protocols enabled on this endpoint.
        /// </summary>
        /// <remarks>Defaults to HTTP/1.x only.</remarks>
        internal HttpProtocols HttpProtocols { get; set; }
    }
}
