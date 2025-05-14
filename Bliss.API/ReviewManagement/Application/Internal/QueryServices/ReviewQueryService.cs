using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ReviewManagement.Domain.Repositories;
using NRG3.Bliss.API.ReviewManagement.Domain.Services;

namespace NRG3.Bliss.API.ReviewManagement.Application.Internal.QueryServices;

/// <summary>
/// Review query service
/// </summary>
/// <param name="reviewRepository">
/// Review repository
/// </param>
public class ReviewQueryService(IReviewRepository reviewRepository,
    IAppointmentRepository appointmentRepository) : IReviewQueryService
{
    /// <inheritdoc />
    public async Task<IEnumerable<Review>> Handle(GetAllReviewsByUserIdQuery query)
    {
        return await reviewRepository.FindReviewsByUserIdAsync(query.UserId);
    }

    public async Task<IEnumerable<Review>> Handle(GetAllReviewsByCompanyIdQuery query)
    {
        return await reviewRepository.FindReviewsByCompanyIdAsync(query.CompanyId);

    }

    public async Task<Appointment?> GetAppointmentByIdAsync(int appointmentId)
    {
        return await appointmentRepository.FindAppointmentByIdAsync(appointmentId);

    }

    /// <inheritdoc />
    public async Task<Review?> Handle(GetReviewByIdQuery query)
    {
        return await reviewRepository.FindReviewByIdAsync(query.ReviewId);
    }
    
    
    public async Task<Review?> Handle(GetReviewByAppointmentIdQuery query)
    {
        return await reviewRepository.FindReviewByAppointmentIdAsync(query.appointmentId);
    }
    
    public async Task<IEnumerable<Review>> GetAllReviewsAsync()
    {
        return await reviewRepository.FindAllReviewsAsync();
    }
}