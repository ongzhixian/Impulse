using Amazon.CDK;
using Amazon.CDK.AWS.SNS;
using Amazon.CDK.AWS.SNS.Subscriptions;
using Amazon.CDK.AWS.SQS;
using Amazon.CDK.AWS.Lambda;

namespace CdkWorkshop
{
    public class CdkWorkshopStack : Stack
    {
        internal CdkWorkshopStack(Construct scope, string id, IStackProps props = null) : base(scope, id, props)
        {
            //  // The CDK includes built-in constructs for most resource types, such as Queues and Topics.
            // var queue = new Queue(this, "CdkWorkshopQueue", new QueueProps
            // {
            //     VisibilityTimeout = Duration.Seconds(300)
            // });

            // var topic = new Topic(this, "CdkWorkshopTopic");

            // topic.AddSubscription(new SqsSubscription(queue));

            // Defines a new lambda resource
            var hello = new Function(this, "HelloHandler", new FunctionProps
            {
                Runtime = Runtime.NODEJS_10_X, // execution environment
                Code = Code.FromAsset("lambda"), // Code loaded from the "lambda" directory
                Handler = "hello.handler" // file is "hello", function is "handler"
            });
        }
    }
}
