using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;
using Serilog.Exceptions;
using Serilog.Formatting.Compact;
using Serilog.Sinks.RollingFile;

namespace API.Template.WebService
{
	/// <summary>
	/// Static class for Application runtime
	/// </summary>
	public static class Program
	{
		/// <summary>
		/// Application entry point
		/// </summary>
		/// <param name="args"></param>
		public static void Main(string[] args)
		{
			using (var sink = new RollingFileSink("log.json", new CompactJsonFormatter(), 1000000, 50))
			{
				Log.Logger = new LoggerConfiguration()
					.MinimumLevel.Debug()
					.MinimumLevel.Override("Microsoft", LogEventLevel.Information)
					.Enrich.FromLogContext()
					.Enrich.WithExceptionDetails()
					.WriteTo.Console()
					.WriteTo.Sink(sink)
					.CreateLogger();
			}

			try
			{
				Log.Information("Starting web host");
				CreateHostBuilder(args).Build().Run();
			}
			catch (Exception ex)
			{
				Log.Error(ex, "Unexpected error");
				throw;
			}
		}

		/// <summary>
		/// Runtime method for creating startup
		/// </summary>
		public static IHostBuilder CreateHostBuilder(string[] args) =>
			Host.CreateDefaultBuilder(args)
				.ConfigureWebHostDefaults(webBuilder =>
				{
					webBuilder.UseStartup<Startup>();
				});
	}
}
