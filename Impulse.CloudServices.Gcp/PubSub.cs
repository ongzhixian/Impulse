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
        private PublisherClient.ClientCreationSettings clientCreationSettings = null;
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

            this.clientCreationSettings = new PublisherClient.ClientCreationSettings(credentials: this.channelCredentials);

            this.logger.LogInformation("PubSub init");
        }

        public async Task<int> PublishMessagesAsync(string projectId, string topicId, IEnumerable<string> messageTexts)
        {
            TopicName topicName = TopicName.FromProjectTopic(projectId, topicId);
            PublisherClient publisher = await PublisherClient.CreateAsync(topicName, clientCreationSettings);

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
    }
}
