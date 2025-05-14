namespace NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Resources;

/// <summary>
/// Resource for creating a review
/// </summary>
/// <param name="UserId">
/// The unique identifier of the user who is creating the review
/// </param>
/// <param name="AppointmentId">
/// The unique identifier of the appointment being reviewed
/// </param>
/// <param name="Rating">
/// The rating given in the review
/// </param>
/// <param name="Comment">
/// The comments provided in the review
/// </param>
/// <param name="ImageUrl">
/// The URL of the image associated with the review
/// </param>
public record CreateReviewResource(
    int UserId,
    int AppointmentId,
    int Rating,
    string Comment,
    string ImageUrl
        
);