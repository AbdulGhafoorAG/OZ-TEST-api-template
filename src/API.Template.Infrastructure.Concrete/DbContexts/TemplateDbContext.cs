
using API.Template.Infrastructure.Concrete.Mapping;
using Microsoft.EntityFrameworkCore;

namespace API.Template.Infrastructure.Concrete.DbContexts
{
	public class TemplateDbContext : DbContext
	{
		public TemplateDbContext(DbContextOptions<TemplateDbContext> options) : base(options)
		{
		}

		protected override void OnModelCreating(ModelBuilder builder)
		{
			if (builder == null)
			{
				return;
			}
			builder.ApplyConfiguration(new TemplateMapping());
		}
	}
}
