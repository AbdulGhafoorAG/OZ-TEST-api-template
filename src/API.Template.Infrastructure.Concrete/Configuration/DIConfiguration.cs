using API.Template.Infrastructure.Concrete.Repositories;
using API.Template.Infrastructure.Concrete.Services;
using API.Template.Infrastructure.Repositories;
using API.Template.Infrastructure.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Template.Infrastructure.Concrete.Configuration
{
	public static class DIConfiguration
	{
		public static void ConfigureConcreteServices(this IServiceCollection services, IConfiguration config)
		{
			services.AddScoped<ITemplateRepository, EntityRepository>();
			services.AddScoped<ITemplateService, TemplateService>();
			services.AddDbContext<DbContext>(
				options => options.UseSqlServer(config.GetConnectionString("TemplateDb"))
			);
		}
	}
}