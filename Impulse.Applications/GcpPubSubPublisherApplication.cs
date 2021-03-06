﻿namespace Impulse.Applications
{
    using Impulse.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class GcpPubSubPublisherApplication : IApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly IServiceProvider serviceProvider;
        private readonly System.Net.IPAddress broadcastIPAddress;
        private readonly int broadcastPort;


        public GcpPubSubPublisherApplication(ILogger<GcpPubSubPublisherApplication> logger, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            //this.broadcastIPAddress = configuration["Application:Broadcast:IPAddress"].AsIPAddress();
            //logger.LogInformation(sss);

            logger.LogTrace("ASAS - trace");
            logger.LogDebug("ASAS - debug");
            logger.LogInformation("ASAS - info");   //
            logger.LogWarning("ASAS - warn");       // 
            logger.LogError("ASAS - error");        //
            logger.LogCritical("ASAS - crit");      // 


        } // public GcpPubSubPublisherApplication (...)

        public Task Run(string[] args)
        {
            return Task.Run(async () =>
            {
                string googleCredentialsFilePath = configuration["Application:GoogleApplicationCredentials"];

                // ZX: PubSub is currently implemented as a standalone class and not a service.
                CloudServices.Gcp.PubSub pubSub = new CloudServices.Gcp.PubSub(
                    this.serviceProvider.GetService<ILogger<CloudServices.Gcp.PubSub>>(),
                    this.configuration
                    );
                
                //this.serviceProvider.GetService<CloudServices.Gcp.PubSub>();
                //CloudServices.Gcp.PubSub pubSub = this.serviceProvider.GetRequiredService<CloudServices.Gcp.PubSub>();
                //this.serviceProvider.GetService<CloudServices.Gcp.PubSub>();


                string project_id = "hci-admin";
                string topic_id = "tax-refund-transaction";
                string[] messages = new string[]
                {
                    "message 1",
                    "message 2",
                };

                var result = await pubSub.PublishMessagesAsync(
                    project_id,
                    topic_id,
                    messages);
                
            });
            
        } // Run(...)

    } // public class UdpServerApplication : IApplication
} // namespace Impulse.Applications