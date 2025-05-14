namespace NRG3.Bliss.API.ReviewManagement.Domain.Model.Queries;

/// <summary>
/// Get all reviews by company id query
/// </summary>
/// <param name="CompanyId">
/// The user id to get reviews for
/// </param>

public record GetAllReviewsByCompanyIdQuery(int CompanyId);