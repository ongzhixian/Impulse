using Amazon;
using Amazon.SimpleEmail;
using Amazon.SimpleEmail.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Impulse.CloudServices.Aws.Ses
{
    // TODO: Further improvements
    // Currently just a simple proof of concept to prove that it works
    // https://docs.aws.amazon.com/ses/latest/DeveloperGuide/examples-send-using-sdk.html
    // Amazon SES console at https://console.aws.amazon.com/ses/
    // https://docs.aws.amazon.com/ses/latest/DeveloperGuide/send-email-simulator.html
    // 
    public interface ISesClient
    {
        void Send();
    }
    public class SesClient : ISesClient
    {
        
        // This address must be verified with Amazon SES.
        static readonly string senderAddress = "zhixian@hotmail.com";

        // Replace recipient@example.com with a "To" address. If your account
        // is still in the sandbox, this address must be verified.
        static readonly string receiverAddress = "overxianz@gmail.com";

        // The configuration set to use for this email. If you do not want to use a
        // configuration set, comment out the following property and the
        // ConfigurationSetName = configSet argument below. 
        //static readonly string configSet = "ConfigSet";

        // The subject line for the email.
        static readonly string subject = "Amazon SES test (AWS SDK for .NET)";

        // The email body for recipients with non-HTML email clients.
        static readonly string textBody = "Amazon SES Test (.NET)\r\n"
                                        + "This email was sent through Amazon SES "
                                        + "using the AWS SDK for .NET.";

        // The HTML body of the email.
        static readonly string htmlBody = @"<html>
<head></head>
<body>
  <h1>Amazon SES Test (AWS SDK for .NET)</h1>
  <p>This email was sent with
    <a href='https://aws.amazon.com/ses/'>Amazon SES</a> using the
    <a href='https://aws.amazon.com/sdk-for-net/'>
      AWS SDK for .NET</a>.</p>
</body>
</html>";

        public void Send()
        {
            using (AmazonSimpleEmailServiceClient client = new AmazonSimpleEmailServiceClient(RegionEndpoint.APSoutheast1))
            {
                SendEmailRequest sendRequest = new SendEmailRequest
                {
                    Source = senderAddress,
                    Destination = new Destination
                    {
                        ToAddresses = new List<string> { receiverAddress }
                    },
                    Message = new Message
                    {
                        Subject = new Content(subject),
                        Body = new Body
                        {
                            Html = new Content
                            {
                                Charset = "UTF-8",
                                Data = htmlBody
                            },
                            Text = new Content
                            {
                                Charset = "UTF-8",
                                Data = textBody
                            }
                        }
                    },
                    // If you are not using a configuration set, comment or remove the following line 
                    //ConfigurationSetName = configSet
                };

                try
                {
                    System.Threading.Tasks.Task<SendEmailResponse> response = client.SendEmailAsync(sendRequest);
                }
                catch (Exception ex)
                {

                }
            }

        }
    }
}
