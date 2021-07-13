using System;
using System.Threading.Tasks;
using API.Template.Infrastructure.Services;
using API.Template.Infrastructure.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace API.Template.WebService.Controllers.V1
{
	/// <summary>
	/// API Controller for Template examples
	/// </summary>
	[Route("v1/template")]
	[ApiController]
	public class TemplateController : ControllerBase
	{
		private readonly ITemplateService _service;

		/// <summary>
		/// Template API controller example
		/// </summary>
		public TemplateController(ITemplateService service)
		{
			_service = service;
		}

		/// <summary>
		/// Health check
		/// </summary>
		[ProducesResponseType(StatusCodes.Status200OK)]
		[HttpGet("status")]
		public ActionResult<TemplateDto> IsAlive()
		{
			return Ok();
		}

		/// <summary>
		/// Returns an entity by its Id
		/// </summary>
		/// <param name="entityId">Entity Id</param>
		/// <returns></returns>
		[ProducesResponseType(StatusCodes.Status400BadRequest)]
		[ProducesResponseType(StatusCodes.Status200OK)]
		[ProducesResponseType(StatusCodes.Status404NotFound)]
		[HttpGet("{entityId}")]
		public async Task<ActionResult<TemplateDto>> GetEntity(Guid entityId)
		{

			try
			{
				var entity = await _service.GetEntityByIdQuery(entityId).ConfigureAwait(false);

				if (entity == null)
				{
					return NotFound();
				}

				return Ok(entity);
			}
			catch (Exception ex)
			{
				Log.Error(ex, "Error for {entityId}", entityId);
				throw;
			}
		}
	}
}