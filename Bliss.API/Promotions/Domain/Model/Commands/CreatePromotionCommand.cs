namespace Bliss.API.Promotions.Domain.Model.Commands;

public record CreatePromotionCommand(
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