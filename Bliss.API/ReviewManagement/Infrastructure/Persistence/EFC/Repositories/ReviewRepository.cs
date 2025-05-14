using Microsoft.EntityFrameworkCore;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ReviewManagement.Domain.Repositories;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NRG3.Bliss.API.ReviewManagement.Infrastructure.Persistence.EFC.Repositories;

public class ReviewRepository(AppDbContext context) : BaseRepository<Review>(context), IReviewRepository
{
    public async Task<IEnumerable<Review>> FindReviewsByUserIdAsync(int userId) =>
        await Context.Set<Review>()
            .Include(r => r.User)
            .Include(r => r.Appointment)
                .ThenInclude(a => a.Service) // Ensure Service is included
            .Include(r => r.Appointment)
                .ThenInclude(a => a.Company)
            .Where(r => r.UserId == userId).ToListAsync();

    public async Task<Review?> FindReviewByAppointmentIdAsync(int appointmentId) =>
        await Context.Set<Review>()
            .Include(r => r.User)
            .Include(r => r.Appointment)
            .ThenInclude(a => a.Service) // Ensure Service is included
            .Include(r => r.Appointment)
            .ThenInclude(a => a.Company)
            .FirstOrDefaultAsync(r => r.AppointmentId == appointmentId);

    public async Task<IEnumerable<Review>> FindReviewsByCompanyIdAsync(int companyId) =>
        await Context.Set<Review>()
            .Include(r => r.User)
            .Include(r => r.Appointment)
                .ThenInclude(a => a.Service) // Ensure Service is included
            .Include(r => r.Appointment)
                .ThenInclude(a => a.Company)
            .Where(r => r.Appointment.CompanyId == companyId).ToListAsync();

    public async Task<Review?> FindReviewByIdAsync(int reviewId) =>
        await Context.Set<Review>()
            .Include(r => r.User)
            .Include(r => r.Appointment)
                .ThenInclude(a => a.Service) // Ensure Service is included
            .Include(r => r.Appointment)
                .ThenInclude(a => a.Company)
            .FirstOrDefaultAsync(r => r.Id == reviewId);

    public async Task<bool> ReviewExistForAppointmentId(int appointmentId) =>
        await Context.Set<Review>().AnyAsync(r => r.AppointmentId == appointmentId);
    
    public async Task<IEnumerable<Review>> FindAllReviewsAsync()
    {
        return await Context.Reviews
            .Include(r => r.User)
            .Include(r => r.Appointment)
            .ThenInclude(a => a.Service)
            .Include(r => r.Appointment)
            .ThenInclude(a => a.Company)
            .ToListAsync();
    }

}