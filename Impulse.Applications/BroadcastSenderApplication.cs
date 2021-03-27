namespace Impulse.Applications
{
    using Impulse.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class BroadcastSenderApplication : IApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;

        public BroadcastSenderApplication(ILogger<BroadcastSenderApplication> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        } // public BroadcastSenderApplication (...)

        public Task Run(string[] args)
        {
            return Task.Run(() =>
            {
                try
                {

                    bool isRunning = true;
                    string message = null;
                    int messageNum = 0;

                    int socketPort = 5005;
                    System.Net.IPEndPoint clientEndpoint = new System.Net.IPEndPoint(System.Net.IPAddress.Broadcast, socketPort);

                    using (var udpClient = Networking.UdpHelper.GetBroadcastSender(clientEndpoint))
                    {
                        while (isRunning)
                        {
                            message = $"Message {messageNum++}";

                            logger.LogInformation($"Broadcasting [{message}] { this.configuration["Application:Version"]}");

                            byte[] bytes = System.Text.Encoding.UTF8.GetBytes(message);

                            udpClient.Send(bytes, bytes.Length);

                            System.Threading.Thread.Sleep(1000);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    throw;
                }

            });
            
        } // Run(...)

    } // public class BroadcastSenderApplication : IApplication
} // namespace Impulse.Applications