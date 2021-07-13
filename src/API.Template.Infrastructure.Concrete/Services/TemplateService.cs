using API.Template.Domain;
using API.Template.Infrastructure.DTOs;
using API.Template.Infrastructure.Repositories;
using API.Template.Infrastructure.Services;
using System;
using System.Threading.Tasks;

namespace API.Template.Infrastructure.Concrete.Services
{
    public class TemplateService : ITemplateService
    {
        private readonly ITemplateRepository _entityRepository;

        public TemplateService(ITemplateRepository entityRepository)
        {
            _entityRepository = entityRepository;
        }

        public async Task<ExampleEntity> GetEntityByIdQuery(Guid entityId)
        {
            return await _entityRepository.GetEntityAsync(entityId).ConfigureAwait(false);
        }

		public async Task<Guid> CreateEntityAsync(TemplateDto newEntity)
		{
			if (newEntity == null)
			{
				throw new ArgumentNullException(nameof(newEntity));
			}

			var entity = new ExampleEntity
			{
				FirstName = newEntity.FirstName,
			};

			_entityRepository.CreateEntity(entity);
			await _entityRepository.SaveAsync().ConfigureAwait(false);

			return entity.SampleId;
		}
	}
}
