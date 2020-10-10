namespace Impulse.Networking
{
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading.Tasks;

    public class TcpTestServer
    {
#pragma warning disable S4487 // Unread "private" fields should be removed
        private readonly ILogger logger;
#pragma warning restore S4487 // Unread "private" fields should be removed

        public TcpTestServer(ILogger<TcpTestServer> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));

        }
#pragma warning disable CA1822 // Mark members as static
        public void Start()
#pragma warning restore CA1822 // Mark members as static
        {
            List<Task> clients = new List<Task>();

#pragma warning disable IDE0017 // Simplify object initialization
            var tcpServer = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
#pragma warning restore IDE0017 // Simplify object initialization
            tcpServer.NoDelay = true;
            tcpServer.SendBufferSize = 1024 * 1024;
            tcpServer.ReceiveBufferSize = 1024 * 1024;
            var socketEndpoint = new IPEndPoint(IPAddress.Any, 51234);

            try
            {
                tcpServer.Bind(socketEndpoint);
                tcpServer.Listen(3);
                while (true)
                {
#pragma warning disable S125 // Sections of code should not be commented out
                            //log.Info("Waiting for connection.");
                    Socket clientSocket = tcpServer.Accept();
#pragma warning restore S125 // Sections of code should not be commented out
                    clients.Add(
                        Task.Run(() => HandleClientConnection(clientSocket))
                        );
#pragma warning disable S125 // Sections of code should not be commented out
                            //log.InfoFormat("Connected. [{0}] clients connected.", clients.Count);
                }
#pragma warning restore S125 // Sections of code should not be commented out

            }
            catch (Exception)
            {
#pragma warning disable S125 // Sections of code should not be commented out
                            //log.Error(ex);
            }
#pragma warning restore S125 // Sections of code should not be commented out
        }

        private static void HandleClientConnection(Socket clientSocket)
        {
            throw new NotImplementedException();
        }

        //private static void xHandleClientConnection(Socket clientSocket)
#pragma warning disable S125 // Sections of code should not be commented out
                            //{
                            //    const int BUFFER_SIZE = 10; // 64KB
                            //    byte[] receiveBytesBuffer = new byte[BUFFER_SIZE];
                            //    int bytesRead;

        //    while (true)
        //    {
        //        try
        //        {
        //            log.Info("Getting the first 4 bytes (message length).");
        //            var receivedBytesCount = 0;
        //            while (receivedBytesCount < 4)
        //            {
        //                try
        //                {
        //                    bytesRead = clientSocket.Receive(receiveBytesBuffer, receivedBytesCount, 4 - receivedBytesCount, SocketFlags.None);
        //                    log.InfoFormat("Received: [{0}], Total received: [{1}], Outstanding: [{2}]",
        //                            bytesRead,
        //                            receivedBytesCount,
        //                            4 - receivedBytesCount
        //                            );
        //                    receivedBytesCount += bytesRead;
        //                }
        //                catch (Exception)
        //                {
        //                    throw;
        //                }
        //            }

        //            // packet length is an integer (4 bytes)
        //            var packetLength = receiveBytesBuffer.GetInt32(0);
        //            log.InfoFormat("Message length is: [{0}]", packetLength);

        //            // After we know the message length, we would then know how many bytes we have to read 
        //            receivedBytesCount = 0;
        //            while (receivedBytesCount < packetLength)
        //            {
        //                log.InfoFormat("Incomplete packet; waiting to read [{0}] bytes.", packetLength - receivedBytesCount);
        //                try
        //                {
        //                    bytesRead = clientSocket.Receive(receiveBytesBuffer, receivedBytesCount, (packetLength - receivedBytesCount), SocketFlags.None);
        //                    receivedBytesCount += bytesRead;
        //                    log.InfoFormat("Received: [{0}], Total received: [{1}], Outstanding: [{2}]",
        //                        bytesRead,
        //                        receivedBytesCount,
        //                        packetLength - receivedBytesCount
        //                        );
        //                }
        //                catch (Exception)
        //                {
        //                    log.InfoFormat("Ye4ah, here's the problem");
        //                    log.InfoFormat("Packet length:  [{0}]", packetLength);
        //                    log.InfoFormat("Buffer size:    [{0}]", BUFFER_SIZE);
        //                    log.InfoFormat("Size:           [{0}]", (packetLength - receivedBytesCount));
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            log.Error(ex);
        //        }
        //    }
        //}

    }
#pragma warning restore S125 // Sections of code should not be commented out
}
