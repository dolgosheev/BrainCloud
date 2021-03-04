using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPSend_ServerSide
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

            var tcpSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            tcpSocket.Bind(endPoint);

            tcpSocket.Listen(10);

            while (true)
            {
                var listener = tcpSocket.Accept();
                var buffer = new byte[256];
                int size;
                var data = new StringBuilder();

                do
                {
                    size = listener.Receive(buffer);
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size));
                } while (listener.Available > 0);

                Console.WriteLine(data);

                listener.Send(Encoding.UTF8.GetBytes("Success!"));

                listener.Shutdown(SocketShutdown.Both);
                listener.Close();
            }
        }
    }
}