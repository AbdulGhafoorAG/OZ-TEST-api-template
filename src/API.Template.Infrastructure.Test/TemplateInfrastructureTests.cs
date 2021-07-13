using System;
using System.Linq;
using System.Threading.Tasks;
using API.Template.Domain;
using API.Template.Infrastructure.DTOs;
using API.Template.Infrastructure.Concrete.Repositories;
using API.Template.Infrastructure.Concrete.Services;
using API.Template.WebService.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace API.Template.Infrastructure.Test
{
	public class TemplateInfrastuctureTests
	{
		[Fact]
		public async Task AddingTemplateTemplateMappingAsync()
		{
			using (var context = Utils.GetContextWithData())
			{
				var entityControllerInMemory = new TemplateController(new TemplateService(new EntityRepository(context)));

				_ = new TemplateDto
				{
					FirstName = "FirstName",
				};

				var expectedTemplateDomain = new ExampleEntity
				{
					FirstName = "FirstName",
				};

				var entity = await entityControllerInMemory.GetEntity(Guid.Parse("00000000-0000-0000-0000-000000000000"));
				var differences = Utils.GetDifferences(((ObjectResult)entity.Result).Value, expectedTemplateDomain);

				Assert.True(differences.Count() == 0);
			}
		}

		[Fact]
		public void DomainObjectDTOTransformationAttributesMappingByName()
		{
			var dummyTemplate = new ExampleEntity
			{
				FirstName = "FirstName"
			};

			var entityDTOResult = TemplateDto.From(dummyTemplate);
			Utils.GetDifferences(dummyTemplate, entityDTOResult);
		}
	}
}
