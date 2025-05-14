namespace NRG3.Bliss.API.ReviewManagement.Domain.Model.Commands;

/// <summary>
/// Update review command
/// </summary>
/// <param name="ReviewId">
/// The review id to update
/// </param>

public record UpdateReviewCommand(int ReviewId, string Comment, int Rating, string ImageUrl);