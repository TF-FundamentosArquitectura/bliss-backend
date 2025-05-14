namespace NRG3.Bliss.API.ReviewManagement.Domain.Model.Commands;
//TODO: Remove unnecessary parameters (Elvia)
/// <summary>
/// Create appointment command
/// </summary>
/// <param name="UserId">
/// The user id to create the review for
/// </param>
/// <param name="AppointmentId">
/// The appointment id to create the review for
/// </param>
/// <param name="Rating">
/// The rating of the review
/// </param>
/// <param name="Comment">
/// The comment of the review
/// </param>
/// <param name="CreatedAt">
/// The date of the review creation
/// </param>
/// <param name="UpdatedAt">
/// The date of the review update
/// </param>
/// <param name="ImageUrl">
/// The image url of the review


public record CreateReviewCommand( int UserId, int AppointmentId, int Rating, string Comment, string ImageUrl);
