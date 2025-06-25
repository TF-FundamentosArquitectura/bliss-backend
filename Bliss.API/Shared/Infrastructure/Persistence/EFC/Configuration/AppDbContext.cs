using Bliss.API.Promotions.Domain.Model.Aggregates;
using Bliss.API.SubscriptionManagement.Domain.Model.Entities;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.IAM.Domain.Model.Aggregates;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;

namespace NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{

    public DbSet<Subscription> Subscriptions { get; set; }
    public DbSet<SubscriptionPlan> SubscriptionPlans { get; set; }
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Company> Companies { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Specialist> Specialists { get; set; }
    public void AddCategory()
    {
        if (!Categories.Any(c => c.Name == "Cuidado Capilar"))
            Categories.Add(new Category
            {
                Name = "Cuidado Capilar",
                Description = "Servicios enfocados en el corte, peinado, coloración y tratamientos para el cabello, diseñados para mejorar su salud y apariencia."
            });
        if (!Categories.Any(c => c.Name == "Manicure y Pedicure"))
            Categories.Add(new Category
            {
                Name = "Manicure y Pedicure",
                Description = "Tratamientos estéticos para manos y pies que incluyen corte, limado, esmaltado, hidratación y decoración de uñas."
            });
        if (!Categories.Any(c => c.Name == "Estética Facial"))
            Categories.Add(new Category
            {
                Name = "Estética Facial",
                Description = "Servicios que abarcan limpieza facial, exfoliación, hidratación y tratamientos especializados para el cuidado de la piel del rostro."
            });
        if (!Categories.Any(c => c.Name == "Depilación"))
            Categories.Add(new Category
            {
                Name = "Depilación",
                Description = "Eliminación del vello corporal mediante métodos como cera caliente, cera fría, hilo o láser, para una piel más suave y estética."
            });
        SaveChanges();



    }
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        builder.AddCreatedUpdatedInterceptor();
        base.OnConfiguring(builder);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        //TODO: Add database configuration modeling here

        builder.Entity<Service>().HasKey(s => s.Id);
        builder.Entity<Service>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Service>().Property(s => s.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Service>().Property(s => s.Price).IsRequired();
        builder.Entity<Service>().Property(s => s.Duration).IsRequired();
        builder.Entity<Service>().Property(s => s.Description).HasMaxLength(500);
        builder.Entity<Service>().Property(s => s.ImageUrl);
        builder.Entity<Specialist>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Specialist>().Property(p => p.Name).IsRequired();
        builder.Entity<Specialist>().HasKey(p => p.Id);
        builder.Entity<Specialist>().Property(p => p.ServiceId).IsRequired();

        builder.Entity<Category>().HasKey(c => c.Id);
        builder.Entity<Category>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Category>().Property(c => c.Name).IsRequired().HasMaxLength(50);
        builder.Entity<Category>().Property(c => c.Description).HasMaxLength(500);

        builder.Entity<Company>().HasKey(c => c.Id);
        builder.Entity<Company>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Company>().Property(c => c.Name).IsRequired().HasMaxLength(100);
        builder.Entity<Company>().Property(c => c.Ruc).HasMaxLength(11);

        builder.Entity<Appointment>().HasKey(a => a.Id);
        builder.Entity<Appointment>().Property(a => a.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Appointment>().Property(a => a.UserId).IsRequired();
        builder.Entity<Appointment>().Property(a => a.CompanyId).IsRequired();
        builder.Entity<Appointment>().Property(a => a.ServiceId).IsRequired();
        builder.Entity<Appointment>().Property(a => a.RegisterAt).IsRequired();
        builder.Entity<Appointment>().Property(a => a.Status).IsRequired().HasMaxLength(50);
        builder.Entity<Appointment>().Property(a => a.ReservationDate).IsRequired();
        builder.Entity<Appointment>().Property(a => a.ReservationStartTime).IsRequired();
        builder.Entity<Appointment>().Property(a => a.Requirements).IsRequired();

        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.FirstName).IsRequired();
        builder.Entity<User>().Property(u => u.LastName).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        builder.Entity<User>().Property(u => u.Email).IsRequired();
        builder.Entity<User>().Property(u => u.Phone).IsRequired();
        builder.Entity<User>().Property(u => u.Dni).IsRequired();
        builder.Entity<User>().Property(u => u.Address).IsRequired();
        builder.Entity<User>().Property(u => u.City).IsRequired();
        builder.Entity<User>().Property(u => u.BirthDate).IsRequired();
        builder.Entity<User>().Property(u => u.Role).IsRequired();

        builder.Entity<Subscription>().HasKey(s => s.Id);
        builder.Entity<Subscription>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Subscription>().Property(s => s.UserId).IsRequired();
        builder.Entity<Subscription>().Property(s => s.SubscriptionPlanId).IsRequired();  // La clave foránea
        builder.Entity<Subscription>().Property(s => s.StartDate).IsRequired();
        builder.Entity<Subscription>().Property(s => s.EndDate).IsRequired();
        builder.Entity<Subscription>().Property(s => s.Status).IsRequired().HasMaxLength(50);
        builder.Entity<Subscription>().Property(s => s.PaymentMethod).HasMaxLength(100);

        builder.Entity<Category>()
            .HasMany(c => c.Services)
            .WithOne(s => s.Category)
            .HasForeignKey(s => s.CategoryId)
            .HasPrincipalKey(c => c.Id);

        builder.Entity<Company>()
            .HasMany(c => c.Services)
            .WithOne(s => s.Company)
            .HasForeignKey(s => s.CompanyId)
            .HasPrincipalKey(c => c.Id);

        builder.Entity<Company>()
            .HasMany(c => c.Appointments)
            .WithOne(a => a.Company)
            .HasForeignKey(a => a.CompanyId)
            .HasPrincipalKey(c => c.Id);

        builder.Entity<Service>()
            .HasMany(s => s.Appointments)
            .WithOne(a => a.Service)
            .HasForeignKey(a => a.ServiceId)
            .HasPrincipalKey(s => s.Id);

        builder.Entity<User>()
            .HasMany(u => u.Appointments)
            .WithOne(a => a.User)
            .HasForeignKey(a => a.UserId)
            .HasPrincipalKey(u => u.Id);

        builder.Entity<Review>()
            .HasKey(r => r.Id);
        builder.Entity<Review>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Review>().Property(r => r.UserId).IsRequired();
        builder.Entity<Review>().Property(r => r.AppointmentId).IsRequired();
        builder.Entity<Review>().Property(r => r.Comment).IsRequired().HasMaxLength(400);
        builder.Entity<Review>().Property(r => r.Rating).IsRequired();
        builder.Entity<Review>().Property(r => r.ImageUrl).HasMaxLength(500);

        builder.Entity<Review>()
            .HasIndex(r => r.AppointmentId)
            .IsUnique();

        builder.Entity<Subscription>()
            .HasOne(s => s.SubscriptionPlan)
            .WithMany(sp => sp.Subscriptions)
            .HasForeignKey(s => s.SubscriptionPlanId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.Entity<SubscriptionPlan>().HasKey(sp => sp.Id);
        builder.Entity<SubscriptionPlan>().Property(sp => sp.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<SubscriptionPlan>().Property(sp => sp.Name).IsRequired().HasMaxLength(100);
        builder.Entity<SubscriptionPlan>().Property(sp => sp.Description).HasMaxLength(500);
        builder.Entity<SubscriptionPlan>().Property(sp => sp.Price).IsRequired();
        builder.Entity<SubscriptionPlan>().Property(sp => sp.DurationDays).IsRequired();

        //Promotion BC
        builder.Entity<Promotion>().HasKey(p => p.Id);
        builder.Entity<Promotion>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Promotion>().Property(p => p.Title).IsRequired().HasMaxLength(100);
        builder.Entity<Promotion>().Property(p => p.Description).IsRequired();
        builder.Entity<Promotion>().Property(p => p.DiscountPercentage).IsRequired();
        builder.Entity<Promotion>().Property(p => p.DiscountAmount).IsRequired();
        builder.Entity<Promotion>().Property(p => p.StartDate).IsRequired();
        builder.Entity<Promotion>().Property(p => p.EndDate).IsRequired();
        builder.Entity<Promotion>().Property(p => p.PromoCode).IsRequired();
        builder.Entity<Promotion>().Property(p => p.MaxUses).IsRequired();
        builder.Entity<Promotion>().Property(p => p.CurrentUses).IsRequired();
        builder.Entity<Promotion>().Property(p => p.MinRequirements).IsRequired();
        builder.Entity<Promotion>().Property(p => p.CompanyId).IsRequired();
        builder.Entity<Promotion>().Property(p => p.CompanyServiceId).IsRequired();

        builder.UseSnakeCaseNamingConvention();
    }
}