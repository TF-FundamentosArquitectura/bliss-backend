using NRG3.Bliss.API.ReviewManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Resources;

namespace NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Transform;

public static class UpdateReviewCommandResourceFromEntityAssembler
{
    public static UpdateReviewCommand ToCommandFromResource(int reviewId, UpdateReviewResource resource)
    {
        return new UpdateReviewCommand(reviewId, resource.Comment, resource.Rating, resource.ImageUrl);
    }
}