using API.Template.Infrastructure.Concrete.Mapping;
using Microsoft.EntityFrameworkCore;

namespace API.Template.Infrastructure.Concrete.DbContexts
{
	public class InMemoryContext : DbContext
	{
		public InMemoryContext(DbContextOptions<InMemoryContext> options) : base(options) { }

		public DbSet<DTOs.TemplateDto> Entity { get; set; }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			if (builder != null)
			{
				builder.ApplyConfiguration(new TemplateMapping());
			}
		}
	}
}
