using NRG3.Bliss.API.ReviewManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.ReviewManagement.Domain.Repositories;

/// <summary>
/// Review repository interface
/// </summary>
public interface IReviewRepository : IBaseRepository<Review>
{
    //TODO: Change the return types to boolean on validation methods (Elvia)
    
    /// <summary>
    /// Find reviews by user id
    /// </summary>
    /// <param name="userId">
    /// The user id to search for
    /// </param>
    /// <returns>
    /// The <see cref="Review"/> if found, otherwise null
    /// </returns>
    Task<IEnumerable<Review>> FindReviewsByUserIdAsync(int userId);

    /// <summary>
    /// Find reviews by appointment id
    /// </summary>
    /// <param name="appointmentId">
    /// The appointment id to search for
    /// </param>
    /// <returns>
    /// The <see cref="Review"/> if found, otherwise null
    /// </returns>

    
    Task<bool> ReviewExistForAppointmentId(int appointmentId);
    
    /// <summary>
    /// Find reviews by company id
    /// </summary>
    /// <param name="companyId">
    /// The company id to search for
    /// </param>
    /// <returns>
    /// The <see cref="Review"/> if found, otherwise null
    /// </returns>
    Task<IEnumerable<Review>> FindReviewsByCompanyIdAsync(int companyId);

    /// <summary>
    /// Find review by id
    /// </summary>
    /// <param name="reviewId">
    /// The review id to search for
    /// </param>
    /// <returns>
    /// The <see cref="Review"/> if found, otherwise null
    /// </returns>
    Task<Review?> FindReviewByIdAsync(int reviewId);
    
    Task<Review?> FindReviewByAppointmentIdAsync(int appointmentId);
    
    Task<IEnumerable<Review>> FindAllReviewsAsync();
    
}