namespace Impulse.Applications
{
    using Impulse.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class UdpServerApplication : IApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;
        private readonly System.Net.IPAddress broadcastIPAddress;
        private readonly int broadcastPort;

        public UdpServerApplication(ILogger<UdpServerApplication> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            //this.broadcastIPAddress = configuration["Application:Broadcast:IPAddress"].AsIPAddress();
            //logger.LogInformation(sss);

            logger.LogInformation("ASAS");

            //this.broadcastIPAddress = System.Net.IPAddress.Parse(configuration["Application:Broadcast:IPAddress"]);

            

        } // public UdpServerApplication (...)

        public Task Run(string[] args)
        {
            return Task.Run(() =>
            {
                using (System.Net.Sockets.Socket s = new System.Net.Sockets.Socket(
                    System.Net.Sockets.AddressFamily.InterNetwork,
                    System.Net.Sockets.SocketType.Dgram,
                    System.Net.Sockets.ProtocolType.Udp))
                {
                    System.Net.IPAddress broadcast = System.Net.IPAddress.Parse("192.168.1.255");

                    byte[] sendbuf = System.Text.Encoding.ASCII.GetBytes(args[0]);

                    System.Net.IPEndPoint ep = new System.Net.IPEndPoint(broadcast, 11000);

                    s.SendTo(sendbuf, ep);
                }

                    
            });
            
        } // Run(...)

    } // public class UdpServerApplication : IApplication
} // namespace Impulse.Applications