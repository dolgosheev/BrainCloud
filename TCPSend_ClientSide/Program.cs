using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace TCPSend_ClientSide
{
    internal class Program
    {
        private static void Main()
        {
            const string ip = "127.0.0.1";
            const int port = 8888;

            var endPoint = new IPEndPoint(
                IPAddress.Parse(ip),
                port);

            var tcpSocket = new Socket(
                AddressFamily.InterNetwork,
                SocketType.Stream,
                ProtocolType.Tcp);

            Console.WriteLine("Type your message :");
            var message = Console.ReadLine();
            var data = Encoding.UTF8.GetBytes(message ?? string.Empty);

            tcpSocket.Connect(endPoint);

            tcpSocket.Send(data);

            var buffer = new byte[256];
            int size;
            var answer = new StringBuilder();

            do
            {
                size = tcpSocket.Receive(buffer);
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size));
            } while (tcpSocket.Available > 0);

            Console.WriteLine(answer);

            tcpSocket.Shutdown(SocketShutdown.Both);
            tcpSocket.Close();

            Console.ReadLine();
        }
    }
}