// Infrastructure/Persistence/EFC/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using Bliss.API.SubscriptionManagement.Domain.Model.Entities;

namespace Bliss.API.SubscriptionManagement.Infrastructure.Persistence.EFC.Repositories
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet para las suscripciones
        public DbSet<Subscription> Subscriptions { get; set; }

        // DbSet para los planes de suscripción
        public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }

        // Otros DbSets si tienes más entidades
    }
}
