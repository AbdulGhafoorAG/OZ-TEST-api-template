using System;
using System.Threading.Tasks;
using API.Template.Domain;
using API.Template.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

namespace API.Template.Infrastructure.Concrete.Repositories
{
	public class EntityRepository : ITemplateRepository
	{
		private readonly DbContext _context;

		public EntityRepository(DbContext context)
		{
			_context = context;
		}

		public void CreateEntity(ExampleEntity entity)
		{
			_ = _context.Set<ExampleEntity>().Add(entity);
		}

		public async Task<ExampleEntity> GetEntityAsync(Guid entityId)
		{
			return await _context.Set<ExampleEntity>()
				.FirstOrDefaultAsync(x => x.SampleId == entityId)
				.ConfigureAwait(false);
		}

		public async Task SaveAsync()
		{
			await _context.SaveChangesAsync().ConfigureAwait(false);
		}

		public void UpdateEntity(ExampleEntity entity)
		{
			_context.Set<ExampleEntity>().Attach(entity);
			_context.Entry(entity).State = EntityState.Modified;
		}
	}
}