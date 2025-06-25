namespace Bliss.API.Promotions.Interfaces.REST.Resources;

public record CreatePromotionResource(
    string Title,
    string Description,
    decimal DiscountPercentage,
    decimal DiscountAmount,
    DateTime StartDate,
    DateTime EndDate,
    string PromoCode,
    int MaxUses,
    string MinRequirements,
    int CompanyId,
    int CompanyServiceId
    );