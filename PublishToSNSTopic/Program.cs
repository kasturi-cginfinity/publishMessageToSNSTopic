namespace PublishToSNSTopicExample
{
    using System;
    using System.Threading.Tasks;
    using Amazon.SimpleNotificationService;
    using Amazon.SimpleNotificationService.Model;
    using Amazon.Runtime;

    /// <summary>
    /// This example publishes a message to an Amazon Simple Notification
    /// Service (Amazon SNS) topic. The code uses the AWS SDK for .NET and
    /// .NET Core 5.0.
    /// </summary>
    public class PublishToSNSTopic
    {
        private const string AccessKey = "AKIAZOVM3S6TFOYOYKJM";
        private const string Secret = "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";

        public static async Task Main()
        {
            string topicArn = "arn:aws:sns:ap-south-1:649976321958:test1";
            string phoneNumber = "1xxxyyyzzzz ";
            string message = "This is a test message.";
            string messageText = phoneNumber+ message;

            BasicAWSCredentials credentials = new BasicAWSCredentials(AccessKey, Secret);
            IAmazonSimpleNotificationService client = new AmazonSimpleNotificationServiceClient(credentials, Amazon.RegionEndpoint.APSouth1);


            await PublishToTopicAsync(client, topicArn, messageText);

        }

        /// <summary>
        /// Publishes a message to an Amazon SNS topic.
        /// </summary>
        /// <param name="client">The initialized client object used to publish
        /// to the Amazon SNS topic.</param>
        /// <param name="topicArn">The ARN of the topic.</param>
        /// <param name="messageText">The text of the message.</param>
        public static async Task PublishToTopicAsync(
            IAmazonSimpleNotificationService client,
            string topicArn,
            string messageText)
        {
            var request = new PublishRequest
            {
                TopicArn = topicArn,
                Message = messageText,
            };

            var response = await client.PublishAsync(request);

            Console.WriteLine($"Successfully published message ID: {response.MessageId}");
        }

        // snippet-end:[SNS.dotnetv3.PublishToSNSTopicExample]
    }
}