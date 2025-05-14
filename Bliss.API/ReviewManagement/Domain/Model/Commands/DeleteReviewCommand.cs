namespace NRG3.Bliss.API.ReviewManagement.Domain.Model.Commands;
/// <summary>
/// Delete review command
/// </summary>
/// <param name="reviewId">
/// The review id to delete
/// </param>

public record DeleteReviewCommand(int reviewId);