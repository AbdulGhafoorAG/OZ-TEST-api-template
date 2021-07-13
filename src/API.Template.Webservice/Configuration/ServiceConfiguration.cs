using System;
using System.IO;
using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Template.WebService.Configuration
{
	/// <summary>
	/// Static class for holding service configuration
	/// </summary>
	public static class ServiceConfiguration
	{
		/// <summary>
		/// Extension method for configuring app services
		/// </summary>
		/// <param name="services"></param>
		public static void ConfigureAppServices(this IServiceCollection services)
		{
			services
				.AddControllers()
				.AddNewtonsoftJson();

			// swagger
			services.AddSwaggerGen(setupAction =>
			{
				setupAction.SwaggerDoc("TemplateAPI",
					new OpenApiInfo()
					{
						Title = "Template API",
						Version = "1"
					});

				var xmlCommentsFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
				var xmlCommentsFullPath = Path.Combine(AppContext.BaseDirectory, xmlCommentsFile);
				
				setupAction.IncludeXmlComments(xmlCommentsFullPath);
			});
		}
	}
}