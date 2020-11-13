using System;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcGreeterClient;

namespace AppServer.GrpcServices
{
    public class GreeterService : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            Console.WriteLine("DONE");
            return Task.FromResult(new HelloReply
            {
                Message = request.Name
            });
        }
    }
}