using Bliss.API.Promotions.Domain.Model.Aggregates;
using Bliss.API.Promotions.Domain.Model.Commands;
using Bliss.API.Promotions.Interfaces.REST.Resources;

namespace Bliss.API.Promotions.Interfaces.REST.Transform;

public class PromotionResourceFromEntityAssembler
{
    public static PromotionResource ToResourceFromEntity(Promotion entity)
    {
        return new PromotionResource(
            entity.Id,
            entity.Title,
            entity.Description,
            entity.DiscountPercentage,
            entity.DiscountAmount,
            entity.StartDate,
            entity.EndDate,
            entity.PromoCode,
            entity.MaxUses,
            entity.CurrentUses,
            entity.MinRequirements,
            entity.CompanyId,
            entity.CompanyServiceId);
    }
}