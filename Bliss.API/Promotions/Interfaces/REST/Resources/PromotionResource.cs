namespace Bliss.API.Promotions.Interfaces.REST.Resources;

public record PromotionResource(
    int Id,
    string Title,
    string Description,
    decimal DiscountPercentage,
    decimal DiscountAmount,
    DateTime StartDate,
    DateTime EndDate,
    string PromoCode,
    int MaxUses,
    int CurrentUses,
    string MinRequirements,
    int CompanyId,
    int CompanyServiceId
);