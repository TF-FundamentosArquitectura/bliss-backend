namespace NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Resources;

/// <summary>
/// Resource for a review
/// </summary>
/// <param name="Id">
/// The unique identifier of the review
/// </param>
/// <param name="UserId">
/// The unique identifier of the user who created the review
/// </param>
/// <param name="Appointment">
/// The simplified appointment resource
/// </param>
/// <param name="Rating">
/// The rating given in the review
/// </param>
/// <param name="Comments">
/// The comments provided in the review
/// </param>
public record ReviewResource(
    int Id,
    int UserId,
    ReviewAppointmentResource Appointment,
    int Rating,
    string Comments,
    string ImageUrl
);