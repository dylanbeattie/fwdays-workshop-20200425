using System;
using System.Threading.Tasks;
using GrpcGreeter;
using Grpc.Net.Client;
using System.Diagnostics;

namespace GrpcGreeterClient {
	class Program {
		private static Stopwatch sw = new Stopwatch();
		static async Task Main(string[] args) {
			using (var channel = GrpcChannel.ForAddress("https://localhost:5001")) {
				var client = new Greeter.GreeterClient(channel);
				while (true) {
					sw.Reset();
					Console.Write(String.Empty.PadLeft(72, '='));
					Console.Write("Enter your name: ");
					var name = Console.ReadLine();
					sw.Start();
					var request = new HelloRequest { Name = name };
					var reply = await client.SayHelloAsync(request);
					sw.Stop();
					Console.WriteLine(reply);
					Console.WriteLine($"gRPC call took {sw.ElapsedMilliseconds} ms");
				}
			}
		}
	}
}
