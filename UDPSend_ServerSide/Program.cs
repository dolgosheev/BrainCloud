using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPSend_ServerSide
{
    internal class Program
    {
        private static void Main()
        {
            const string ip = "127.0.0.1";
            const int port = 6666;

            var endPoint = new IPEndPoint(
                IPAddress.Parse(ip),
                port);

            var udpSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Dgram,
                ProtocolType.Udp);

            udpSocket.Bind(endPoint);


            while (true)
            {
                var buffer = new byte[256];
                var data = new StringBuilder();
                EndPoint senderEndpoint = new IPEndPoint(IPAddress.Any, 0);

                do
                {
                    udpSocket.ReceiveFrom(buffer, ref senderEndpoint);
                    data.Append(Encoding.UTF8.GetString(buffer));
                } while (udpSocket.Available > 0);

                Console.WriteLine(data);

                udpSocket.SendTo(Encoding.UTF8.GetBytes("Success!"), senderEndpoint);

                //udpSocket.Shutdown(SocketShutdown.Both);
                //udpSocket.Close();
            }
        }
    }
}