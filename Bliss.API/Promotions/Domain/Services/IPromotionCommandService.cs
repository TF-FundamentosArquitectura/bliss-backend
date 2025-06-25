using Bliss.API.Promotions.Domain.Model.Aggregates;
using Bliss.API.Promotions.Domain.Model.Commands;

namespace Bliss.API.Promotions.Domain.Services;

public interface IPromotionCommandService
{
    Task<Promotion> Handle(CreatePromotionCommand command);
    Task<bool> Handle(DeletePromotionByIdCommand command);
    //Task<Promotion> UpdatePromotionAsync(Promotion promotion);
    //Task<bool> ActivatePromotionAsync(Guid id);
    //Task<bool> DeactivatePromotionAsync(Guid id);
}