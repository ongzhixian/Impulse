namespace Impulse.Applications
{
    using Impulse.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class MulticastSenderApplication : IApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;

        public MulticastSenderApplication(ILogger<MulticastSenderApplication> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        } // public MulticastServerApplication (...)

        public Task Run(string[] args)
        {
            return Task.Run(() =>
            {
                bool isRunning = true;
                string message = null;
                int messageNum = 0;

                using (var udpClient = Networking.UdpHelper.GetUdpSender("224.5.6.7", 4567))
                {
                    while (isRunning)
                    {
                        message = $"Message {messageNum++}";

                        Console.WriteLine($"Broadcasting [{message}]");
                        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(message);

                        udpClient.Send(bytes, bytes.Length);

                        System.Threading.Thread.Sleep(1000);
                    }
                }
            });
            
        } // Run(...)

    } // public class MulticastServerApplication : IApplication
} // namespace Impulse.Applications