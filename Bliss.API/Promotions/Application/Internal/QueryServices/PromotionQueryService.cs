using Bliss.API.Promotions.Domain.Model.Aggregates;
using Bliss.API.Promotions.Domain.Model.Queries;
using Bliss.API.Promotions.Domain.Model.Repositories;
using Bliss.API.Promotions.Domain.Services;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace Bliss.API.Promotions.Application.Internal.QueryServices;

public class PromotionQueryService(
    IPromotionRepository promotionRepository
) : IPromotionQueryService
{
    public async Task<IEnumerable<Promotion>> Handle(GetAllPromotionsQuery query)
    {
        return await promotionRepository.ListAsync();
    }

    public async Task<Promotion?> Handle(GetPromotionByIdQuery query)
    {
        return await promotionRepository.FindByIdAsync(query.Id);
    }
}