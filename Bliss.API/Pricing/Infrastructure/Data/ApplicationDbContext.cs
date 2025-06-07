// Infrastructure/Data/ApplicationDbContext.cs
using Bliss.API.Domain.Pricing;
using Bliss.API.Domain.Services;
using Bliss.API.Domain.Specialists;
using Bliss.API.Domain.Companies;
using Microsoft.EntityFrameworkCore;

namespace Bliss.API.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Domain.Pricing.Pricing> Pricings { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Specialist> Specialists { get; set; }
        public DbSet<Company> Companies { get; set; }
    }
}