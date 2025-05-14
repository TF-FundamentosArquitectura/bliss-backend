using NRG3.Bliss.API.ReviewManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Resources;
using NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Transform;

namespace NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Transform;

/// <summary>
/// Assembler to create a ReviewResource from a Review entity
/// </summary>
public static class ReviewResourceFromEntityAssembler
{
    /// <summary>
    /// Assembles a ReviewResource from a Review entity
    /// </summary>
    /// <param name="review">
    /// The <see cref="Review"/> entity to assemble the resource from
    /// </param>
    /// <returns>
    /// The <see cref="ReviewResource"/> resource assembled from the entity
    /// </returns>
    public static ReviewResource ToResourceFromEntity(Review review)
    {
        var simplifiedAppointmentResource = ReviewAppointmentFromEntityAssembler.ToResourceFromEntity(review.Appointment);

        return new ReviewResource(
            review.Id,
            review.UserId,
            simplifiedAppointmentResource,
            review.Rating,
            review.Comment,
            review.ImageUrl
        );
    }
}