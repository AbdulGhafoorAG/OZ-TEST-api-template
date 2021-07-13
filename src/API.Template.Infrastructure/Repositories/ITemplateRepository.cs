using System;
using System.Threading.Tasks;
using API.Template.Domain;

namespace API.Template.Infrastructure.Repositories
{
	public interface ITemplateRepository
	{
		Task<ExampleEntity> GetEntityAsync(Guid entityId);

		void UpdateEntity(ExampleEntity entity);

		void CreateEntity(ExampleEntity entity);

		Task SaveAsync();
	}
}