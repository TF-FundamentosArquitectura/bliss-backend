using Bliss.API.Promotions.Domain.Model.Commands;
using Bliss.API.Promotions.Interfaces.REST.Resources;

namespace Bliss.API.Promotions.Interfaces.REST.Transform;

public class CreatePromotionCommandFromResourceAssembler
{
    public static CreatePromotionCommand ToCommandFromResource(CreatePromotionResource resource)
    {
        return new CreatePromotionCommand(
            resource.Title,
            resource.Description,
            resource.DiscountPercentage,
            resource.DiscountAmount,
            resource.StartDate,
            resource.EndDate,
            resource.PromoCode,
            resource.MaxUses,
            resource.MinRequirements,
            resource.CompanyId,
            resource.CompanyServiceId);
    }
}
