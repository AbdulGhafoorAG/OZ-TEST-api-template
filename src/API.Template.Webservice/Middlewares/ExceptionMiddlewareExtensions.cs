using System;
using System.Net;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using Serilog;

namespace API.Template.WebService.Middlewares
{
	/// <summary>
	/// Static class for middleware exceptions
	/// </summary>
	public static class ExceptionMiddlewareExtensions
	{
		/// <summary>
		/// Extension method for configuring custom API exception handling
		/// </summary>
		public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger, Action<HttpContext> exceptionManager = null)
		{
			app.UseExceptionHandler(appError =>
			{
				appError.Run(async context =>
				{
					if (exceptionManager != null)
					{
						exceptionManager(context);
					}
					else
					{
						context.Response.ContentType = "application/json";

						var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
						if (contextFeature != null)
						{
							context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
							logger.Error(contextFeature.Error, "@");

							var response = new
							{
								context.Response.StatusCode,
								Message = "Internal Server Error."
							};

							await context.Response.WriteAsync(JsonConvert.SerializeObject(response)).ConfigureAwait(false);
						}
					}
				});
			});
		}
	}
}