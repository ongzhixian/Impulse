namespace Impulse.Applications
{
    using Impulse.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class GcpPubSubSubscriberApplication : IApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly IServiceProvider serviceProvider;
        private readonly System.Net.IPAddress broadcastIPAddress;
        private readonly int broadcastPort;


        public GcpPubSubSubscriberApplication(ILogger<GcpPubSubSubscriberApplication> logger, IConfiguration configuration, IServiceProvider serviceProvider)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
            this.serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));

            //this.broadcastIPAddress = configuration["Application:Broadcast:IPAddress"].AsIPAddress();
            //logger.LogInformation(sss);

            logger.LogTrace("GcpPubSubSubscriberApplication - trace");
            logger.LogDebug("GcpPubSubSubscriberApplication - debug");
            logger.LogInformation("ASAS - info");   //
            logger.LogWarning("ASAS - warn");       // 
            logger.LogError("ASAS - error");        //
            logger.LogCritical("ASAS - crit");      // 


        } // public GcpPubSubSubscriberApplication (...)


        void DoWork(object message, System.Threading.CancellationToken cancellationToken)
        {
            // TODO: Something that can translate PubsubMessage to "Impulse" standards
            /*
            message
            {{ "data": "TWVzc2FnZSBudW1iZXIgMQ==", "messageId": "2061986867003835", "publishTime": "2021-02-20T14:30:03.214Z" }}
                Attributes: {{ }}
                Data: {Google.Protobuf.ByteString}
                MessageId: "2061986867003835"
                OrderingKey: ""
                PublishTime: {"2021-02-20T14:30:03.214Z"}
            message.ToDictionary()
            Count = 5
                [0]: {[Data, Google.Protobuf.ByteString]}
                [1]: {[Attributes, { }]}
                [2]: {[MessageId, 2061986867003835]}
                [3]: {[PublishTime, "2021-02-20T14:30:03.214Z"]}
                [4]: {[OrderingKey, ]}
            */


            Console.WriteLine("In doWork of GcpPubSubSubscriberApplication");
        }

        //void ProcessMessage<T>(T message, System.Threading.CancellationToken cancellationToken)
        //{
        //    Console.WriteLine("In doWork of GcpPubSubSubscriberApplication");
        //}

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
                string subscription_id = "test_sub_id";

                Task subscriptionTask = pubSub.SubscribeAsync(project_id, subscription_id, DoWork);

                await subscriptionTask;

                //string[] messages = new string[]
                //{
                //    "message 1",
                //    "message 2",
                //};

                //var result = await pubSub.PublishMessagesAsync(
                //    project_id,
                //    topic_id,
                //    messages);

            });
            
        } // Run(...)

    } // public class UdpServerApplication : IApplication
} // namespace Impulse.Applications