namespace NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Resources;

/// <summary>
/// Resource for updating a review
/// </summary>
/// <param name="Comment">
/// The updated comment for the review
/// </param>
/// <param name="Rating">
/// The updated rating for the review
/// </param>
/// <param name="ImageUrl">
/// The updated image URL for the review
/// </param>
public record UpdateReviewResource(string Comment, int Rating, string ImageUrl);