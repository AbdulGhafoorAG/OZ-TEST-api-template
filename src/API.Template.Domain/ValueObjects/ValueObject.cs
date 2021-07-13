using System.ComponentModel.DataAnnotations;

namespace API.Template.Domain.ValueObjects
{
	public class ValueObject
	{
		[Required]
		[EmailAddressAttribute]
		public string PrimaryEmail { get; set; }

		[EmailAddressAttribute]
		public string AlternateEmail { get; set; }

		public string HomePhone { get; set; }

		public string WorkPhone { get; set; }

		[Required]
		public string CellPhone { get; set; }	
	}
}