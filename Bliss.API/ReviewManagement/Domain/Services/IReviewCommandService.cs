using NRG3.Bliss.API.ReviewManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Commands;

namespace NRG3.Bliss.API.ReviewManagement.Domain.Services;

/// <summary>
/// Review command service interface
/// </summary>
public interface IReviewCommandService
{
    /// <summary>
    /// Handle create review command
    /// </summary>
    /// <param name="command">
    /// The <see cref="CreateReviewCommand"/> command
    /// </param>
    /// <returns>
    /// The <see cref="Review"/> object with the created review
    /// </returns>
    Task<Review?> Handle(CreateReviewCommand command);
    
    /// <summary>
    /// Handle delete review command
    /// </summary>
    /// <param name="command">
    /// The <see cref="DeleteReviewCommand"/> command
    /// </param>
    /// <returns>
    /// The <see cref="Task"/> object
    /// </returns>
    Task Handle(DeleteReviewCommand command);

    /// <summary>
    /// Handle update review command
    /// </summary>
    /// <param name="command">
    /// The <see cref="UpdateReviewCommand"/> command
    /// </param>
    /// <returns>
    /// The <see cref="Review"/> object with the updated review
    /// </returns>
    Task<Review?> Handle(UpdateReviewCommand command);
}