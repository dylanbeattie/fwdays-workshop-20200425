using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace GrpcGreeter {
	public class Program {
		public static void Main(string[] args) {
			CreateHostBuilder(args).Build().Run();
		}

		// Additional configuration is required to successfully run gRPC on macOS.
		// For instructions on how to configure Kestrel and gRPC clients on macOS, visit https://go.microsoft.com/fwlink/?linkid=2099682
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureLogging(logging => {
					logging.ClearProviders();
					logging.AddConsole();
				})
				.ConfigureWebHostDefaults(webBuilder => {
					webBuilder.ConfigureKestrel(options => {
						// Setup a HTTP/2 endpoint without TLS.
						options.ListenAnyIP(5000, o => o.Protocols = HttpProtocols.Http2);
						options.UseSslIfFileExists(5001, @"D:\workshop.ursatile.com.pfx");
					});
					webBuilder.UseStartup<Startup>();
				});
	}

	public static class KestrelServerExtensions {
		public static void UseSslIfFileExists(this KestrelServerOptions options, int port, string pfxFilePath, string password = null) {
			if (File.Exists(pfxFilePath)) {
				options.Listen(IPAddress.Any, port, listen => listen.UseHttps(pfxFilePath, password));
			}
		}
	}
}

