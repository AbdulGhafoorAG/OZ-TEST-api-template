using System;
using API.Template.Domain;

namespace API.Template.Infrastructure.DTOs
{
	public class TemplateDto
	{
		public Guid Id { get; set; }

		public string FirstName { get; set; }

		public static TemplateDto From(ExampleEntity entity)
		{
			if (entity == null)
			{
				return null;
			}

			return new TemplateDto
			{
				Id = entity.SampleId,
				FirstName = entity.FirstName
			};
		}
	}
}