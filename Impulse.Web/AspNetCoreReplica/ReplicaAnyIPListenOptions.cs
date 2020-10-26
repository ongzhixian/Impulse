using System;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Server.Kestrel.Core.Internal;
using Microsoft.Extensions.Logging;

namespace Impulse.Web.AspNetCoreReplica
{
    /// <summary>
    /// https://github.com/dotnet/aspnetcore/blob/0c2ee920a17fc11ecc6b5fe8febe330262a2d69b/src/Servers/Kestrel/Core/src/AnyIPListenOptions.cs
    /// </summary>
    internal class ReplicaAnyIPListenOptions : ReplicaListenOptions
    {
        internal ReplicaAnyIPListenOptions(int port)
            : base(new IPEndPoint(IPAddress.IPv6Any, port))
        {
        }

        internal override async Task BindAsync(ReplicaAddressBindContext context)
        {
            // when address is 'http://hostname:port', 'http://*:port', or 'http://+:port'
            try
            {
                await base.BindAsync(context).ConfigureAwait(false);
            }
            catch (Exception ex) when (!(ex is IOException))
            {
                context.Logger.LogDebug(ReplicaCoreStrings.FormatFallbackToIPv4Any(IPEndPoint.Port));

                // for machines that do not support IPv6
                IPEndPoint = new IPEndPoint(IPAddress.Any, IPEndPoint.Port);
                await base.BindAsync(context).ConfigureAwait(false);
            }
        }
    }
}
