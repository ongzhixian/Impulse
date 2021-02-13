namespace Impulse.Applications
{
    using Impulse.Common;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Threading.Tasks;

    public class UdpClientApplication : IApplication
    {
        private readonly ILogger logger;
        private readonly IConfiguration configuration;



        public UdpClientApplication(ILogger<UdpClientApplication> logger, IConfiguration configuration)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));

        } // public UdpClientApplication(...)

        public Task Run(string[] args)
        {
            return Task.Run(() =>
            {
                


                try
                {

                    //System.Net.IPAddress socketIPAddress = System.Net.IPAddress.Parse("224.5.6.7");
                    //int socketPort = 4567;

                    //System.Net.Sockets.UdpClient udpClient = new System.Net.Sockets.UdpClient();
                    //udpClient.Client.SetSocketOption(System.Net.Sockets.SocketOptionLevel.Socket, System.Net.Sockets.SocketOptionName.ReuseAddress, true);
                    //udpClient.JoinMulticastGroup(socketIPAddress, System.Net.IPAddress.Any);
                    //udpClient.Client.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, socketPort));

                    //const int BUFFER_LENGTH = 1024 * 64; // To handler messages from zero bytes up to 64KB
                    //                                     //byte[] bufferByteArray = new byte[BUFFER_LENGTH];
                    //int bytesReceived;

                    //System.Net.IPEndPoint clientEndpoint = new System.Net.IPEndPoint(0, 0);

                    //while (true)
                    //{
                    //    byte[] bufferByteArray = udpClient.Receive(ref clientEndpoint);

                    //    string message = System.Text.Encoding.UTF8.GetString(bufferByteArray).Trim();

                    //    Console.WriteLine($"Bytes received: [{message}]");
                    //}


                    /////
                    const int BUFFER_LENGTH = 1024 * 64; // To handler messages from zero bytes up to 64KB
                                                         //byte[] bufferByteArray = new byte[BUFFER_LENGTH];
                    int bytesReceived;

                    System.Net.IPEndPoint clientEndpoint = new System.Net.IPEndPoint(System.Net.IPAddress.Any, 0);



                    using (var udpClient = Networking.UdpHelper.GetUdpReceiver("224.5.6.7", 4567))
                    {

                        while (true)
                        {
                            byte[] bufferByteArray = udpClient.Receive(ref clientEndpoint);

                            string message = System.Text.Encoding.UTF8.GetString(bufferByteArray).Trim();

                            Console.WriteLine($"Bytes received: [{message}]");
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    Console.WriteLine(e.StackTrace);
                    throw;
                }



                // Same thing but using sockets
                //System.Net.Sockets.Socket socket = null;

                //try
                //{
                //    socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp);
                //    socket.SetSocketOption(System.Net.Sockets.SocketOptionLevel.Socket, System.Net.Sockets.SocketOptionName.ReuseAddress, true);
                //    socket.SetSocketOption(System.Net.Sockets.SocketOptionLevel.IP, System.Net.Sockets.SocketOptionName.AddMembership, new System.Net.Sockets.MulticastOption(socketIPAddress, System.Net.IPAddress.Any));
                //    socket.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, socketPort));


                //    const int BUFFER_LENGTH = 1024 * 64; // To handler messages from zero bytes up to 64KB
                //    byte[] bufferByteArray = new byte[BUFFER_LENGTH];
                //    int bytesReceived;

                //    while (true)
                //    {
                //        bytesReceived = socket.Receive(bufferByteArray);

                //        string message = System.Text.Encoding.UTF8.GetString(bufferByteArray, 0, bytesReceived).Trim();

                //        Console.WriteLine($"Bytes received: {bytesReceived}: [{message}]");
                //    }

                //}
                //catch (Exception)
                //{
                //    throw;
                //}

            });

        } // Run(...)

        public static System.Net.Sockets.Socket CreateUdpMulticastClientSocket(System.Net.IPAddress socketIPAddress, int socketPort)
        {
            System.Net.Sockets.Socket socket = null;

            try
            {
                socket = new System.Net.Sockets.Socket(System.Net.Sockets.AddressFamily.InterNetwork, System.Net.Sockets.SocketType.Dgram, System.Net.Sockets.ProtocolType.Udp);
                socket.SetSocketOption(System.Net.Sockets.SocketOptionLevel.Socket, System.Net.Sockets.SocketOptionName.ReuseAddress, true);
                socket.SetSocketOption(System.Net.Sockets.SocketOptionLevel.IP, System.Net.Sockets.SocketOptionName.AddMembership, new System.Net.Sockets.MulticastOption(socketIPAddress, System.Net.IPAddress.Any));
                socket.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, socketPort));
            }
            catch (Exception)
            {

                throw;
            }

            return socket;

        }

    } // public class UdpClientApplication : IApplication
} // namespace Impulse.Applications