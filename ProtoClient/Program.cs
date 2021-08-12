using Grpc.Core;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ProtoInterAction;

namespace ProtoClient
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var channel = new Channel("127.0.0.1:30051", ChannelCredentials.Insecure);

            var client = new TestClass.TestClassClient(channel);

            IList<string> names = new List<string>
            {
                "Alexander",
                "Marina",
                "Alice",
            };

            Console.Write("Input you password : ");
            var pass = Console.ReadLine();

            var status = client.Auth(new ClientData
            {
                ClientId = 1,
                ClientName = names[new Random().Next(0, names.Count)],
                ClientPassword = pass ?? string.Empty
            });

            Console.WriteLine($"Status -> {status.Answer}");

            if (status.Status)
            {
                while (channel.State != ChannelState.TransientFailure || channel.State != ChannelState.Shutdown)
                {
                    try
                    {
                        var reply = client.SayHello(new HelloRequest { Name = names[new Random().Next(0, names.Count)] });
                        Console.WriteLine("Greeting: " + reply.Message);
                        Task.Delay(1500).Wait();
                    }
                    catch (RpcException e)
                    {
                        Console.WriteLine($"Disconnected exception : {e.Status}");
                        break;
                    }
                }
            }

            channel.ShutdownAsync().Wait();
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }
}
