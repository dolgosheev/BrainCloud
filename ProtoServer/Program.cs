using Grpc.Core;
using System;
using System.Threading.Tasks;
using ProtoInterAction;

namespace ProtoServer
{
    internal class GreeterImpl : TestClass.TestClassBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            return Task.FromResult(new HelloReply { Message = "Server say hello to " + request.Name.ToUpper() });
        }

        public override Task<ServerAnswer> Auth(ClientData request, ServerCallContext context)
        {
            string answer = "access denied";
            bool status = false;


            if (request != null)
            {
                if (request.ClientPassword == "password")
                {
                    answer = $"Hello {request.ClientName}";
                    status = true;
                }
            }

            return Task.FromResult(new ServerAnswer
            {
                Answer = answer,
                Status = status
            });
        }
    }

    internal class Program
    {
        private const int Port = 30051;

        public static void Main(string[] args)
        {
            var server = new Server
            {
                Services = { TestClass.BindService(new GreeterImpl()) },
                Ports = { new ServerPort("localhost", Port, ServerCredentials.Insecure) }
            };
            server.Start();

            Console.WriteLine("Greeter server listening on port " + Port);
            Console.WriteLine("Press any key to stop the server...");
            Console.ReadKey();

            server.ShutdownAsync().Wait();
        }
    }
}
