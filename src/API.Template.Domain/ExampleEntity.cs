using API.Template.Domain.ValueObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace API.Template.Domain
{
	public class ExampleEntity
	{
		public Guid SampleId { get; set; }

		[RequiredAttribute]
		[MaxLengthAttribute(25)]
		public string FirstName { get; set; }

		public IEnumerable<String> SampleCollection { get; set; }

		[RequiredAttribute]
		public ValueObject ValueObject { get; set; }
	}
}