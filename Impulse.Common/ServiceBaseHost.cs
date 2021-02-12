using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace Impulse.Common
{
    public class ServiceBaseHost : System.ServiceProcess.ServiceBase
    {
        private readonly IHost host = null;
        private readonly ILogger logger = null;

        //public DummyApplication(ILogger<DummyApplication> logger, IConfiguration configuration)
        //{
        //    this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        //    this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        //    DemoLogging();
        //} // public DummyApplication(...)


        public ServiceBaseHost(ILogger<ServiceBaseHost> logger, IHost host)
        {
            this.host = host;
            this.logger = logger;
        }

        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            //host.Services.GetService<IApplication>().Run(args);
            host.StartAsync();
        }

        protected override void OnStop()
        {
            base.OnStop();
            this.logger.LogInformation("Service stopped.");
            //Log("Stopped");
        }

    }
}
