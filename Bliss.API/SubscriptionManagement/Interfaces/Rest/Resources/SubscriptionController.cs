// Interfaces/Rest/Resources/SubscriptionController.cs
using Bliss.API.SubscriptionManagement.Application.Internal.CommandServices;
using Bliss.API.SubscriptionManagement.Application.Internal.CommandServices.Commands;
using Bliss.API.SubscriptionManagement.Application.Internal.CommandServices.CommandHandlers;
using Bliss.API.SubscriptionManagement.Application.Internal.QueryServices;
using Bliss.API.SubscriptionManagement.Domain.Model.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Bliss.API.SubscriptionManagement.Interfaces.Rest.Resources
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : ControllerBase
    {
        private readonly ISubscriptionQueryService _queryService;
        private readonly CreateSubscriptionCommandHandler _createSubscriptionCommandHandler;
        private readonly UpdateSubscriptionCommandHandler _updateSubscriptionCommandHandler;
        private readonly DeleteSubscriptionCommandHandler _deleteSubscriptionCommandHandler; // Añadir el manejador para eliminar

        // Inyectar los manejadores correctos
        public SubscriptionController(ISubscriptionQueryService queryService, 
            CreateSubscriptionCommandHandler createSubscriptionCommandHandler,
            UpdateSubscriptionCommandHandler updateSubscriptionCommandHandler,
            DeleteSubscriptionCommandHandler deleteSubscriptionCommandHandler) // Registrar el manejador de eliminación
        {
            _queryService = queryService;
            _createSubscriptionCommandHandler = createSubscriptionCommandHandler;
            _updateSubscriptionCommandHandler = updateSubscriptionCommandHandler;
            _deleteSubscriptionCommandHandler = deleteSubscriptionCommandHandler; // Inyectar el manejador de eliminación
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
            // Usar el manejador de CreateSubscriptionCommand
            await _createSubscriptionCommandHandler.HandleAsync(command);
            return CreatedAtAction(nameof(GetSubscriptionById), new { id = command.SubscriptionPlanId }, null);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateSubscription([FromBody] UpdateSubscriptionCommand command)
        {
            // Usar el manejador de UpdateSubscriptionCommand
            await _updateSubscriptionCommandHandler.HandleAsync(command);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteSubscription(int id)
        {
            // Usar el manejador de eliminación de suscripción
            await _deleteSubscriptionCommandHandler.HandleAsync(id); // Llamar al manejador de eliminación con el ID de la suscripción
            return NoContent();
        }
    }
}
