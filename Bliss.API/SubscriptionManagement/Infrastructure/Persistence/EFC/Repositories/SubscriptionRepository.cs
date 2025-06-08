// Infrastructure/Persistence/EFC/Repositories/SubscriptionRepository.cs
using Bliss.API.Infrastructure.Data;  // Cambiar la importación de ApplicationDbContext a AppDbContext
using Bliss.API.SubscriptionManagement.Domain.Model.Entities;  // Asegúrate de importar la entidad Subscription
using Bliss.API.SubscriptionManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace Bliss.API.SubscriptionManagement.Infrastructure.Persistence.EFC.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly AppDbContext _context;  // Cambiar a AppDbContext

        public SubscriptionRepository(AppDbContext context)  // Cambiar aquí también
        {
            _context = context;
        }

        // Crear una nueva suscripción
        public async Task AddAsync(Subscription subscription)
        {
            await _context.Subscriptions.AddAsync(subscription);
            await _context.SaveChangesAsync();
        }

        // Obtener una suscripción por ID
        public async Task<Subscription> GetByIdAsync(int id)
        {
            return await _context.Subscriptions
                .Include(s => s.SubscriptionPlan)  // Cargar la relación de SubscriptionPlan
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        // Obtener todas las suscripciones
        public async Task<IEnumerable<Subscription>> GetAllAsync()
        {
            return await _context.Subscriptions
                .Include(s => s.SubscriptionPlan)  // Cargar la relación de SubscriptionPlan
                .ToListAsync();
        }

        // Actualizar una suscripción
        public async Task UpdateAsync(Subscription subscription)
        {
            _context.Subscriptions.Update(subscription);
            await _context.SaveChangesAsync();
        }

        // Eliminar una suscripción por ID
        public async Task DeleteAsync(int id)
        {
            var subscription = await GetByIdAsync(id);
            if (subscription != null)
            {
                _context.Subscriptions.Remove(subscription);
                await _context.SaveChangesAsync();
            }
        }
    }
}
