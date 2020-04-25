using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;


namespace SignalRConsole {
	class Program {
		static async Task Main(string[] args) {
			var url = "https://workshop.ursatile.com:5001/chatHub";
			Console.WriteLine("Connecting to SignalR...");
			var connection = new HubConnectionBuilder().WithUrl(url).Build();
			connection.On<string, string>("ReceiveMessage", (s1, s2) => ReceiveMessage(s1, s2));
			await connection.StartAsync();
			Console.WriteLine($"Connected to SignalR at {url}");
			Console.Write("Enter your name: ");
			var name = Console.ReadLine();
			while (true) {
				var message = Console.ReadLine();
				if (name == "quit") break;
				await connection.SendAsync("SendMessage", name, message);
			}
			await connection.StopAsync();
		}

		static void ReceiveMessage(string name, string message) {
			Console.WriteLine($"{DateTime.Now.ToString("HH:mm:ss")} {name}: {message}");
		}
	}
}
