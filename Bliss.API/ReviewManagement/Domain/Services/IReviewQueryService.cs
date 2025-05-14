// IReviewQueryService.cs

using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Queries;

namespace NRG3.Bliss.API.ReviewManagement.Domain.Services;

/// <summary>
/// Review query service interface
/// </summary>
public interface IReviewQueryService
{
    /// <summary>
    /// Handle get review by id query
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetReviewByIdQuery"/> query
    /// </param>
    /// <returns>
    /// The <see cref="Review"/> object with the review
    /// </returns>
    Task<Review?> Handle(GetReviewByIdQuery query);

    /// <summary>
    /// Handle get all reviews by user id query
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllReviewsByUserIdQuery"/> query
    /// </param>
    /// <returns>
    /// The <see cref="IEnumerable{Review}"/> object with the reviews
    /// </returns>
    Task<IEnumerable<Review>> Handle(GetAllReviewsByUserIdQuery query);

    /// <summary>
    /// Handle get all reviews by company id query
    /// </summary>
    /// <param name="query">
    /// The <see cref="GetAllReviewsByCompanyIdQuery"/> query
    /// </param>
    /// <returns>
    /// The <see cref="IEnumerable{Review}"/> object with the reviews
    /// </returns>
    Task<IEnumerable<Review>> Handle(GetAllReviewsByCompanyIdQuery query);
    
    Task<Review>
        Handle(GetReviewByAppointmentIdQuery query);
    
    Task<Appointment?> GetAppointmentByIdAsync(int appointmentId);  
    
    Task<IEnumerable<Review>> GetAllReviewsAsync();
}