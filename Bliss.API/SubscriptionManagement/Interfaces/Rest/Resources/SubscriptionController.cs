// Interfaces/Rest/Resources/SubscriptionController.cs

using Bliss.API.SubscriptionManagement.Application.Internal.CommandServices;
using Bliss.API.SubscriptionManagement.Application.Internal.QueryServices;
using Bliss.API.SubscriptionManagement.Application.Internal.CommandServices.Commands;
using Bliss.API.SubscriptionManagement.Domain.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bliss.API.SubscriptionManagement.Interfaces.Rest.Resources
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionQueryService _queryService;
        private readonly ISubscriptionCommandService _commandService;

        public SubscriptionController(ISubscriptionQueryService queryService, ISubscriptionCommandService commandService)
        {
            _queryService = queryService;
            _commandService = commandService;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Subscription>> GetSubscriptionById(int id)
        {
            var subscription = await _queryService.GetByIdAsync(id);
            if (subscription == null)
            {
                return NotFound();
            }
            return Ok(subscription);
        }

        [HttpPost]
        public async Task<ActionResult> CreateSubscription([FromBody] CreateSubscriptionCommand command)
        {
            await _commandService.CreateSubscriptionAsync(command);
            return CreatedAtAction(nameof(GetSubscriptionById), new { id = command.SubscriptionId }, null);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSubscription([FromBody] UpdateSubscriptionCommand command)
        {
            await _commandService.UpdateSubscriptionAsync(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubscription(int id)
        {
            await _commandService.DeleteSubscriptionAsync(id);
            return NoContent();
        }
    }
}