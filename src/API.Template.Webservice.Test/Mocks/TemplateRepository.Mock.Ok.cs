using API.Template.Domain;
using API.Template.Infrastructure.Repositories;
using System;
using System.Threading.Tasks;

namespace API.Template.WebService.Test.Mocks
{
    class TemplateRepositoryMockOk : ITemplateRepository
    {
        public void CreateEntity(ExampleEntity entity)
        {
            throw new NotImplementedException();
        }

#pragma warning disable CS1998
		public async Task<ExampleEntity> GetEntityAsync(Guid entityId)
        {
            return new ExampleEntity
            {
                FirstName = "First Name",
                SampleId = Guid.NewGuid()
            };
        }
#pragma warning restore CS1998

		public Task SaveAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateEntity(ExampleEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}
