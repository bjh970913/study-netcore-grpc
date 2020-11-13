using System;
using System.Net.Http;
using System.Threading.Tasks;
using Grpc.Core;
using GrpcGreeterClient;

namespace AppClient
{
    
    class Program
    {
        static async Task Main(string[] args)
        {
            var channel = new Channel("127.0.0.1:5000", ChannelCredentials.Insecure);

            var client = new Greeter.GreeterClient(channel);
            var reply = await client.SayHelloAsync(
                new HelloRequest {Name = "GreeterClient"});
            Console.WriteLine("Greeting: " + reply.Message);
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
        
        private static HttpClientHandler CreateHttpHandler()
        {
            var handler = new HttpClientHandler();

            // if (includeClientCertificate)
            {
                // Load client certificate
                // var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                // var certPath = Path.Combine(basePath!, "Certs", "client.pfx");
                // var clientCertificate = new X509Certificate2(certPath, "1111");
                // handler.ClientCertificates.Add(clientCertificate);
            }

            return handler;
        }
    }
}