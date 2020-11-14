using Amazon;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Impulse.CloudServices.Aws.Sns
{
    // https://console.aws.amazon.com/sns/home

    public class SnsClient
    {
        
        public async System.Threading.Tasks.Task CreateTopicAsync()
        {
            AmazonSimpleNotificationServiceClient snsClient = new AmazonSimpleNotificationServiceClient(RegionEndpoint.APSoutheast1);

            // Create an Amazon SNS topic.
            CreateTopicRequest createTopicRequest = new CreateTopicRequest("MyTopic");
            CreateTopicResponse createTopicResponse = await snsClient.CreateTopicAsync(createTopicRequest);

            // Print the topic ARN.
            Console.WriteLine("TopicArn: " + createTopicResponse.TopicArn);

            // Print the request ID for the CreateTopicRequest action.
            Console.WriteLine("CreateTopicRequest: " + createTopicResponse.ResponseMetadata.RequestId);

        }

        public async System.Threading.Tasks.Task SubscribeAsync()
        {
            AmazonSimpleNotificationServiceClient snsClient = new AmazonSimpleNotificationServiceClient(RegionEndpoint.APSoutheast1);

            string topicArn = "";

            // Subscribe an email endpoint to an Amazon SNS topic.
            SubscribeRequest subscribeRequest = new SubscribeRequest(topicArn, "email", "name@example.com");
            SubscribeResponse subscribeResponse = await snsClient.SubscribeAsync(subscribeRequest);

            // Print the request ID for the SubscribeRequest action.
            Console.WriteLine("SubscribeRequest: " + subscribeResponse.ResponseMetadata.RequestId);
            Console.WriteLine("To confirm the subscription, check your email.");
        }

        public async System.Threading.Tasks.Task RemoveTopicAsync()
        {
            AmazonSimpleNotificationServiceClient snsClient = new AmazonSimpleNotificationServiceClient(RegionEndpoint.APSoutheast1);

            string topicArn = "";

            // Delete an Amazon SNS topic.
            DeleteTopicRequest deleteTopicRequest = new DeleteTopicRequest(topicArn);
            DeleteTopicResponse deleteTopicResponse = await snsClient.DeleteTopicAsync(deleteTopicRequest);

            // Print the request ID for the DeleteTopicRequest action.
            Console.WriteLine("DeleteTopicRequest: " + deleteTopicResponse.ResponseMetadata.RequestId);
        }

        public async System.Threading.Tasks.Task UnsubscribeAsync()
        {
            AmazonSimpleNotificationServiceClient snsClient = new AmazonSimpleNotificationServiceClient(RegionEndpoint.APSoutheast1);

            string topicArn = "";

            // Delete an Amazon SNS topic.
            UnsubscribeRequest unsubscribeRequest = new UnsubscribeRequest(topicArn);
            UnsubscribeResponse unsubscribeResponse = await snsClient.UnsubscribeAsync(unsubscribeRequest);

            // Print the request ID for the DeleteTopicRequest action.
            Console.WriteLine("UnsubscribeRequest: " + unsubscribeResponse.ResponseMetadata.RequestId);
        }
    }

}
