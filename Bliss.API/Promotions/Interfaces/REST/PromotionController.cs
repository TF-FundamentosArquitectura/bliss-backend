using System.Net.Mime;
using Bliss.API.Promotions.Domain.Model.Commands;
using Bliss.API.Promotions.Domain.Model.Queries;
using Bliss.API.Promotions.Domain.Services;
using Bliss.API.Promotions.Interfaces.REST.Resources;
using Bliss.API.Promotions.Interfaces.REST.Transform;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace Bliss.API.Promotions.Interfaces.REST
{
    [Route("api/[controller]")]
    [ApiController]
    public class PromotionController(
        IPromotionCommandService promotionCommandService,
        IPromotionQueryService promotionQueryService
    ) : ControllerBase
    {
        [HttpGet]
        public async Task<ActionResult> GetAllPromotions()
        {
            var query = new GetAllPromotionsQuery();
            var result = await promotionQueryService.Handle(query);

            if (result is null || !result.Any()) return NotFound("No promotions found.");

            var promotionResources = result.Select(PromotionResourceFromEntityAssembler.ToResourceFromEntity);

            return Ok(promotionResources);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult> GetPromotionById(int id)
        {
            var query = new GetPromotionByIdQuery(id);
            var result = await promotionQueryService.Handle(query);

            if (result is null) return NotFound("No promotion found.");

            var promotionResources = PromotionResourceFromEntityAssembler.ToResourceFromEntity(result);

            return Ok(promotionResources);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePromotionById(int id)
        {
            var command = new DeletePromotionByIdCommand(id);
            var result = await promotionCommandService.Handle(command);

            if (result is false) return NotFound("No promotion found.");

            return Ok("Promotion deleted successfully.");
        }

        [HttpPost]
        public async Task<ActionResult> CreatePromotion([FromBody] CreatePromotionResource resource)
        {
            var command = CreatePromotionCommandFromResourceAssembler.ToCommandFromResource(resource);
            var result = await promotionCommandService.Handle(command);

            if (result is null) return BadRequest("Failed to create promotion.");

            var promotionResource = PromotionResourceFromEntityAssembler.ToResourceFromEntity(result);
            return CreatedAtAction(nameof(CreatePromotion), promotionResource);
        }
    }
}