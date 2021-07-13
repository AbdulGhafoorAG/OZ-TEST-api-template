using System;

namespace API.Template.Domain.Exceptions
{
	public class EntityNotFoundException : Exception
	{
		public Guid EntityId { get; }

		public EntityNotFoundException()
		{
		}

		public EntityNotFoundException(Guid entityId) : base($"Entity {entityId} does not exist.")
		{
			EntityId = entityId;
		}

		public EntityNotFoundException(string message) : base(message)
		{
		}

		public EntityNotFoundException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}
}
