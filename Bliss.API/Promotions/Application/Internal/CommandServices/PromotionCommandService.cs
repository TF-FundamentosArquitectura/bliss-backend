using Bliss.API.Promotions.Domain.Model.Aggregates;
using Bliss.API.Promotions.Domain.Model.Commands;
using Bliss.API.Promotions.Domain.Model.Repositories;
using Bliss.API.Promotions.Domain.Services;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace Bliss.API.Promotions.Application.Internal.CommandServices;

public class PromotionCommandService(
    IPromotionRepository promotionRepository,
    IUnitOfWork unitOfWork
) : IPromotionCommandService
{
    public async Task<Promotion> Handle(CreatePromotionCommand command)
    {
        var promotion = new Promotion(command);

        await promotionRepository.AddAsync(promotion);
        await unitOfWork.CompleteAsync();

        return promotion;
    }

    public async Task<bool> Handle(DeletePromotionByIdCommand command)
    {
        var promotion = await promotionRepository.FindByIdAsync(command.Id);

        if (promotion == null) return false;

        promotionRepository.Remove(promotion);
        await unitOfWork.CompleteAsync();

        return true;
    }
}