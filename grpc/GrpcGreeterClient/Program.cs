using System;
using System.Threading.Tasks;
using GrpcGreeter;
using Grpc.Net.Client;
using System.Diagnostics;

namespace GrpcGreeterClient {
	class Program {
		private static Stopwatch sw = new Stopwatch();
		static async Task Main(string[] args) {
			string host;
			try {
				host = new Uri(args[0]).ToString();
			} catch (Exception) {
				host = "https://localhost:5001";
			}
			Console.WriteLine($"Connecting to gRPC provider on {host}");
			using (var channel = GrpcChannel.ForAddress(host)) {
				var client = new Greeter.GreeterClient(channel);
				var request = new HelloRequest { Name = "Test" };
				var reply = await client.SayHelloAsync(request);
				Console.WriteLine(reply);
				while (true) {
					sw.Reset();
					Console.WriteLine(String.Empty.PadLeft(72, '='));
					Console.Write("Enter your name: ");
					var name = Console.ReadLine();
					sw.Start();
					request = new HelloRequest { Name = name };
					reply = await client.SayHelloAsync(request);
					sw.Stop();
					Console.WriteLine(reply);
					Console.WriteLine($"gRPC call took {sw.ElapsedMilliseconds} ms");
				}
			}
		}
	}
}
