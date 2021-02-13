using System;
using System.Collections.Generic;
using System.Text;

namespace Impulse.Networking
{
    public class UdpHelper
    {
        public static System.Net.Sockets.UdpClient GetUdpReceiver(string ipAddressString, int port)
        {
            // TODO: Check
            System.Net.IPAddress socketIPAddress = System.Net.IPAddress.Parse(ipAddressString);
            int socketPort = port;

            System.Net.Sockets.UdpClient udpClient = new System.Net.Sockets.UdpClient();
            udpClient.Client.SetSocketOption(System.Net.Sockets.SocketOptionLevel.Socket, System.Net.Sockets.SocketOptionName.ReuseAddress, true);
            udpClient.JoinMulticastGroup(socketIPAddress, System.Net.IPAddress.Any);
            udpClient.Client.Bind(new System.Net.IPEndPoint(System.Net.IPAddress.Any, socketPort));

            return udpClient;
        }

        public static System.Net.Sockets.UdpClient GetUdpSender(string ipAddressString, int port)
        {
            // TODO: Check
            System.Net.IPAddress socketIPAddress = System.Net.IPAddress.Parse(ipAddressString);
            int socketPort = port;

            System.Net.Sockets.UdpClient udpClient = new System.Net.Sockets.UdpClient();
            udpClient.JoinMulticastGroup(socketIPAddress);
            udpClient.Connect(new System.Net.IPEndPoint(socketIPAddress, socketPort));

            return udpClient;
        }
    }
}
