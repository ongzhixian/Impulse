namespace Impulse.Applications
{
    using Impulse.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class BroadcastReceiverApplication : IApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;

        public BroadcastReceiverApplication(ILogger<BroadcastReceiverApplication> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        } // public MulticastReceiverApplication (...)

        public Task Run(string[] args)
        {
            return Task.Run(() =>
            {
                try
                {
                    int socketPort = 5005;
                    System.Net.IPEndPoint clientEndpoint = new System.Net.IPEndPoint(System.Net.IPAddress.Any, socketPort);
                    using (var udpClient = Networking.UdpHelper.GetBroadcastReceiver(clientEndpoint))
                    {

                        while (true)
                        {
                            byte[] bufferByteArray = udpClient.Receive(ref clientEndpoint);

                            string message = System.Text.Encoding.UTF8.GetString(bufferByteArray).Trim();

                            logger.LogInformation($"Bytes received: [{message}] {this.configuration["Application:Version"]}");
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

    } // public class MulticastReceiverApplication : IApplication
} // namespace Impulse.Applications