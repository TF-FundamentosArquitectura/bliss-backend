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
    public DbSet<Appointment> Appointments { get; set; }
    public DbSet<Review> Reviews { get; set; }
    public DbSet<Service> Services { get; set; }
    public DbSet<Company> Companies { get; set; }
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
        
        builder.UseSnakeCaseNamingConvention();
    }
}