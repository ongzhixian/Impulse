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

        public static System.Net.Sockets.Socket CreateUdpMulticastServerSocket(System.Net.IPAddress socketIPAddress, int socketPort)
        {
            System.Net.Sockets.Socket socket = null;

            try
            {
                socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp);

                // About time-to-live values
                // https://technet.microsoft.com/en-us/library/cc731236(v=ws.10).aspx
                socket.SetSocketOption(System.Net.Sockets.SocketOptionLevel.IP, System.Net.Sockets.SocketOptionName.MulticastTimeToLive, 32);

                socket.Connect(new System.Net.IPEndPoint(socketIPAddress, socketPort));
            }
            catch (Exception)
            {

                throw;
            }

            return socket;

        }

        public UdpServerApplication(ILogger<UdpServerApplication> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

            //this.broadcastIPAddress = configuration["Application:Broadcast:IPAddress"].AsIPAddress();
            //logger.LogInformation(sss);

            logger.LogTrace("ASAS - trace");
            logger.LogDebug("ASAS - debug");
            logger.LogInformation("ASAS - info");   //
            logger.LogWarning("ASAS - warn");       // 
            logger.LogError("ASAS - error");        //
            logger.LogCritical("ASAS - crit");      // 
            
            //this.broadcastIPAddress = System.Net.IPAddress.Parse(configuration["Application:Broadcast:IPAddress"]);

        } // public UdpServerApplication (...)

        public Task Run(string[] args)
        {
            return Task.Run(() =>
            {
                //using (System.Net.Sockets.Socket s = new System.Net.Sockets.Socket(
                //    System.Net.Sockets.AddressFamily.InterNetwork,
                //    System.Net.Sockets.SocketType.Dgram,
                //    System.Net.Sockets.ProtocolType.Udp))
                //{
                //    System.Net.IPAddress broadcast = System.Net.IPAddress.Parse("192.168.1.255");

                //    byte[] sendbuf = System.Text.Encoding.ASCII.GetBytes(args[0]);

                //    System.Net.IPEndPoint ep = new System.Net.IPEndPoint(broadcast, 11000);

                //    s.SendTo(sendbuf, ep);
                //}

                //int socketPort;                         // Server
                //System.Net.IPAddress socketIPAddress;   // Server

                //socketPort = 4567;
                //socketIPAddress = System.Net.IPAddress.Parse("224.5.6.7");

                //System.Net.Sockets.UdpClient udpClient = new System.Net.Sockets.UdpClient();
                //udpClient.JoinMulticastGroup(socketIPAddress);
                //udpClient.Connect(new System.Net.IPEndPoint(socketIPAddress, socketPort));

                //bool isRunning = true;
                //string message = null;
                //int messageNum = 0;


                //while (isRunning)
                //{
                //    message = $"Message {messageNum++}";

                //    Console.WriteLine($"Broadcasting [{message}]");
                //    byte[] bytes = System.Text.Encoding.UTF8.GetBytes(message);

                //    udpClient.Send(bytes, bytes.Length);

                //    System.Threading.Thread.Sleep(1000);
                //}


                bool isRunning = true;
                string message = null;
                int messageNum = 0;


                using (var udpClient = Networking.UdpHelper.GetUdpSender("224.5.6.7", 4567))
                {

                    while (isRunning)
                    {
                        message = $"Message {messageNum++}";

                        Console.WriteLine($"Broadcasting [{message}]");

                        logger.LogInformation($"Broadcasting [{message}]");

                        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(message);

                        udpClient.Send(bytes, bytes.Length);

                        System.Threading.Thread.Sleep(1000);
                    }
                }


                // Working (same thing but using sockets
                //using (System.Net.Sockets.Socket udpSocket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp))
                //{
                //    // Not really needed for sender
                //    udpSocket.SetSocketOption(System.Net.Sockets.SocketOptionLevel.IP, System.Net.Sockets.SocketOptionName.AddMembership, new System.Net.Sockets.MulticastOption(socketIPAddress));

                //    // About time-to-live values
                //    // https://technet.microsoft.com/en-us/library/cc731236(v=ws.10).aspx
                //    udpSocket.SetSocketOption(System.Net.Sockets.SocketOptionLevel.IP, System.Net.Sockets.SocketOptionName.MulticastTimeToLive, 1);

                //    udpSocket.Connect(new System.Net.IPEndPoint(socketIPAddress, socketPort));

                //    // This creates the letters ABCDEFGHIJ
                //    bool isRunning = true;
                //    string message = null;
                //    int messageNum = 0;

                //    while (isRunning)
                //    {
                //        message = $"Message {messageNum++}";

                //        Console.WriteLine($"Broadcasting [{message}]");
                //        byte[] bytes = System.Text.Encoding.UTF8.GetBytes(message);

                //        udpSocket.Send(bytes, bytes.Length, System.Net.Sockets.SocketFlags.None);

                //        System.Threading.Thread.Sleep(1000);
                //    }

                //    udpSocket.Shutdown(System.Net.Sockets.SocketShutdown.Both);
                //}



            });
            
        } // Run(...)

    } // public class UdpServerApplication : IApplication
} // namespace Impulse.Applications