using System;
using System.Threading.Tasks;
using API.Template.Domain;
using API.Template.Infrastructure.DTOs;

namespace API.Template.Infrastructure.Services
{
	public interface ITemplateService
	{
		Task<ExampleEntity> GetEntityByIdQuery(Guid entityId);

		Task<Guid> CreateEntityAsync(TemplateDto newEntity);
	}
}