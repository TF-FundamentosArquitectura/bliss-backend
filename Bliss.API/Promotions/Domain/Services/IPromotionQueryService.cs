using Bliss.API.Promotions.Domain.Model.Aggregates;
using Bliss.API.Promotions.Domain.Model.Queries;

namespace Bliss.API.Promotions.Domain.Services;

public interface IPromotionQueryService
{
    Task<IEnumerable<Promotion>> Handle(GetAllPromotionsQuery query);
    Task<Promotion?> Handle(GetPromotionByIdQuery query);
}