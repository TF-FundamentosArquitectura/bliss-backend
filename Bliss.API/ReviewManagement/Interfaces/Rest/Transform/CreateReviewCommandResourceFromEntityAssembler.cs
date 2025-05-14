using NRG3.Bliss.API.ReviewManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Resources;

namespace NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Transform;

public static class CreateReviewCommandResourceFromEntityAssembler
{
    public static CreateReviewCommand ToCommandFromResource(CreateReviewResource resource)
    {
        return new CreateReviewCommand(
            resource.UserId,
            resource.AppointmentId,
            resource.Rating,
            resource.Comment,
            resource.ImageUrl
        );
    }
}