using Microsoft.AspNetCore.Server.Kestrel;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Impulse.Web.AspNetCoreReplica
{
    public class ReplicaAdhoc
    {

        public static ReplicaKestrelConfigurationLoader Configure(KestrelServerOptions kestrelServerOptions, IConfiguration config)
        {
            var loader = new ReplicaKestrelConfigurationLoader(kestrelServerOptions, config);
            loader.Load();
            ReplicaKestrelConfigurationLoader ConfigurationLoader = loader;
            return loader;
        }

    }
}
