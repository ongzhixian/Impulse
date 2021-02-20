using Google.Apis.Auth.OAuth2;
using Google.Cloud.PubSub.V1;
using Grpc.Auth;
using Grpc.Core;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace Impulse.CloudServices.Gcp
{
    public class PubSub
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;

        private GoogleCredential googleCredential = null;
        private ChannelCredentials channelCredentials = null;
        //private PublisherClient.ClientCreationSettings clientCreationSettings = null;
        // private PublisherClient.Settings settings = new PublisherClient.Settings();

        public PubSub(ILogger<PubSub> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            string credentialsJsonFilePath = configuration["Application:GoogleApplicationCredentials"];

            using (FileStream jsonFileStream = new FileStream(credentialsJsonFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                this.googleCredential = GoogleCredential.FromStream(jsonFileStream);
                this.channelCredentials = this.googleCredential.ToChannelCredentials();
            }

            //this.clientCreationSettings = new PublisherClient.ClientCreationSettings(credentials: this.channelCredentials);

            this.logger.LogInformation("PubSub init");
        }

        public async Task<int> PublishMessagesAsync(string projectId, string topicId, IEnumerable<string> messageTexts)
        {
            TopicName topicName = TopicName.FromProjectTopic(projectId, topicId);
            PublisherClient publisher = await PublisherClient.CreateAsync(topicName,
                new PublisherClient.ClientCreationSettings(credentials: this.channelCredentials));

            int publishedMessageCount = 0;
            var publishTasks = messageTexts.Select(async text =>
            {
                try
                {
                    string message = await publisher.PublishAsync(text);
                    Console.WriteLine($"Published message {message}");
                    Interlocked.Increment(ref publishedMessageCount);
                }
                catch (Exception exception)
                {
                    Console.WriteLine($"An error ocurred when publishing message {text}: {exception.Message}");
                }
            });

            await Task.WhenAll(publishTasks);

            return publishedMessageCount;



            //clientCreationSettings.Credentials
            //PublisherServiceApiSettings publisherServiceApiSettings = new PublisherServiceApiSettings();



            //clientCreationSettings.PublisherServiceApiSettings
            //clientCreationSettings.Credentials


            //Channel channel = new Channel(
            //    PublisherClient.DefaultEndpoint.Host,
            //    PublisherClient.DefaultEndpoint.Port,
            //    googleCredential.ToChannelCredentials());
            //PublisherClient publisher2 = await PublisherClient.CreateAsync(topicName, clientCreationSettings, settings);



            //PublisherServiceApiClientBuilder bld = new PublisherServiceApiClientBuilder();
            //var credential = GoogleCredential.FromJson(@"{""your_credentials_json_itself"":""here""}");
            //var channel = new Grpc.Core.Channel(PublisherServiceApiClient.DefaultEndpoint.ToString(), credential.ToChannelCredentials());

            //PublisherServiceApiClient.DefaultScopes

            //var publisher3 = bld.
            //PublisherServiceApiClientBuilder x = new PublisherServiceApiClientBuilder
            //{
            //    CredentialsPath = jsonPath
            //};
            //PublisherServiceApiClient client = x.Build();

        }

        //public Subscription CreatePushSubscription(string projectId, string topicId, string subscriptionId, string pushEndpoint)
        public async Task CreatePushSubscriptionAsync(string projectId, string topicId, string subscriptionId, string pushEndpoint)
        {
            var subscriptionName = new SubscriptionName(projectId, subscriptionId);

            // Pull messages from the subscription using SubscriberClient.
            SubscriberClient subscriber = await SubscriberClient.CreateAsync(subscriptionName);
            List<PubsubMessage> receivedMessages = new List<PubsubMessage>();
            // Start the subscriber listening for messages.
            await subscriber.StartAsync((msg, cancellationToken) =>
            {
                receivedMessages.Add(msg);
                Console.WriteLine($"Received message {msg.MessageId} published at {msg.PublishTime.ToDateTime()}");
                Console.WriteLine($"Text: '{msg.Data.ToStringUtf8()}'");
                // Stop this subscriber after one message is received.
                // This is non-blocking, and the returned Task may be awaited.
                subscriber.StopAsync(TimeSpan.FromSeconds(15));
                // Return Reply.Ack to indicate this message has been handled.
                return Task.FromResult(SubscriberClient.Reply.Ack);
            });

            //SubscriberServiceApiClient subscriber = SubscriberServiceApiClient.Create();
            //TopicName topicName = TopicName.FromProjectTopic(projectId, topicId);
            //SubscriptionName subscriptionName = SubscriptionName.FromProjectSubscription(projectId, subscriptionId);

            //PushConfig pushConfig = new PushConfig { PushEndpoint = pushEndpoint };

            //// The approximate amount of time in seconds (on a best-effort basis) Pub/Sub waits for the
            //// subscriber to acknowledge receipt before resending the message.
            //var ackDeadlineSeconds = 60;
            //var subscription = subscriber.CreateSubscription(subscriptionName, topicName, pushConfig, ackDeadlineSeconds);
            //return subscription;
        }

        public Task<SubscriberClient.Reply> ProcMessage(PubsubMessage pubSubMessage, CancellationToken ct)
        {
            int messageCount = 0;
            bool acknowledge = true;
            string text = System.Text.Encoding.UTF8.GetString(pubSubMessage.Data.ToArray());
            Console.WriteLine($"Message {pubSubMessage.MessageId}: {text}");
            Interlocked.Increment(ref messageCount);
            return Task.FromResult(acknowledge ? SubscriberClient.Reply.Ack : SubscriberClient.Reply.Nack);
        }

        public SubscriberClient.Reply ProcMessage2(PubsubMessage pubSubMessage, CancellationToken ct)
        {
            int messageCount = 0;
            bool acknowledge = true;
            string text = System.Text.Encoding.UTF8.GetString(pubSubMessage.Data.ToArray());
            Console.WriteLine($"Message {pubSubMessage.MessageId}: {text}");
            Interlocked.Increment(ref messageCount);

            return acknowledge ? SubscriberClient.Reply.Ack : SubscriberClient.Reply.Nack;
        }

        public Task<SubscriberClient.Reply> ProcMessage3(PubsubMessage pubSubMessage, CancellationToken ct, Action a)
        {
            bool acknowledge = true;

            a();

            return Task.FromResult(acknowledge ? SubscriberClient.Reply.Ack : SubscriberClient.Reply.Nack);
        }

        public void xxxDoWork()
        {

        }

        public async Task<int> ShowMessagesForSubscriptionAsync(string projectId, string subscriptionId)
        {
            //string projectId = "";
            //string subscriptionId = "";

            var subscriptionName = new SubscriptionName(projectId, subscriptionId);

            var subscription = await SubscriberClient.CreateAsync(subscriptionName,
                new SubscriberClient.ClientCreationSettings(credentials: this.channelCredentials)
                );

            
            int messageCount = 0;

            //SubscriberClient.Reply

            

            Task startTask = subscription.StartAsync(ProcMessage);

            await subscription.StartAsync((pubSubMessage, cancellationToken) =>
                 ProcMessage3(pubSubMessage, cancellationToken, xxxDoWork)
            );


            //Task startTask = subscription.StartAsync((pubSubMessage, cancellationToken) =>
            //{
            //    bool acknowledge = true;
            //    string text = System.Text.Encoding.UTF8.GetString(pubSubMessage.Data.ToArray());
            //    Console.WriteLine($"Message {pubSubMessage.MessageId}: {text}");
            //    Interlocked.Increment(ref messageCount);
            //    return Task.FromResult(acknowledge ? SubscriberClient.Reply.Ack : SubscriberClient.Reply.Nack);

            //});

            await subscription.StopAsync(CancellationToken.None);
            // Lets make sure that the start task finished successfully after the call to stop.
            await startTask;
            return messageCount;

        }

        //public Task<SubscriberClient.Reply> OnReceivePubsubMessage(PubsubMessage pubSubMessage, CancellationToken ct, Action doWork)
        //{
        //    bool acknowledge = true;

        //    doWork(pubSubMessage, ct);

        //    return Task.FromResult(acknowledge ? SubscriberClient.Reply.Ack : SubscriberClient.Reply.Nack);
        //}

        public Task<SubscriberClient.Reply> OnReceivePubsubMessage(PubsubMessage pubSubMessage, CancellationToken ct, Action<object, CancellationToken> doWork)
        {
            bool acknowledge = true;

            doWork(pubSubMessage, ct);

            return Task.FromResult(acknowledge ? SubscriberClient.Reply.Ack : SubscriberClient.Reply.Nack);
        }



        public async Task SubscribeAsync(string projectId, string subscriptionId, Action<object, CancellationToken> doWork)
        {
            var subscriptionName = new SubscriptionName(projectId, subscriptionId);

            var subscription = await SubscriberClient.CreateAsync(subscriptionName,
                new SubscriberClient.ClientCreationSettings(credentials: this.channelCredentials)
                );

            //Task startTask = subscription.StartAsync(ProcMessage);
            await subscription.StartAsync((pubSubMessage, cancellationToken) =>
                 OnReceivePubsubMessage(pubSubMessage, cancellationToken, doWork)
            );


            //Task startTask = subscription.StartAsync((pubSubMessage, cancellationToken) =>
            //{
            //    bool acknowledge = true;
            //    string text = System.Text.Encoding.UTF8.GetString(pubSubMessage.Data.ToArray());
            //    Console.WriteLine($"Message {pubSubMessage.MessageId}: {text}");
            //    Interlocked.Increment(ref messageCount);
            //    return Task.FromResult(acknowledge ? SubscriberClient.Reply.Ack : SubscriberClient.Reply.Nack);

            //});

            //await subscription.StopAsync(CancellationToken.None);
            //// Lets make sure that the start task finished successfully after the call to stop.
            //await startTask;
            //return messageCount;

        }


    }
}
