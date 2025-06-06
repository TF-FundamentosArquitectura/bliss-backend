// Infrastructure/Persistence/EFC/Repositories/SubscriptionRepository.cs
using Bliss.API.SubscriptionManagement.Domain.Model.Entities;
using Bliss.API.SubscriptionManagement.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace Bliss.API.SubscriptionManagement.Infrastructure.Persistence.EFC.Repositories
{
    public class SubscriptionRepository : ISubscriptionRepository
    {
        private readonly ApplicationDbContext _context;

        public SubscriptionRepository(ApplicationDbContext context)
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
