using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using API.Template.WebService.Configuration;
using API.Template.WebService.Middlewares;
using Serilog;
using API.Template.Infrastructure.Concrete.Configuration;

namespace API.Template.WebService
{
	/// <summary>
	/// Runtime startup class
	/// </summary>
	public class Startup
	{
		/// <summary>
		/// Runtime startup
		/// </summary>
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		/// <summary>
		/// Application configuration
		/// </summary>
		public IConfiguration Configuration { get; }

		/// <summary>
		/// This method gets called by the runtime. Use this method to add services to the container.
		/// </summary>
		public void ConfigureServices(IServiceCollection services)
		{
			services.ConfigureAppServices();
			services.ConfigureConcreteServices(Configuration);
		}

		/// <summary>
		/// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		/// </summary>
		public static void Configure(IApplicationBuilder app)
		{
#if DEBUG
			app.UseDeveloperExceptionPage();
#endif

			app.ConfigureExceptionHandler(Log.Logger);

			app.UseRouting();

			app.UseAuthorization();

#if DEBUG
			app.UseSwagger();

			app.UseSwaggerUI(setupAction =>
			{
				setupAction.SwaggerEndpoint("/swagger/TemplateAPI/swagger.json", "Template API");
				setupAction.RoutePrefix = "";
			});
#endif

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}

