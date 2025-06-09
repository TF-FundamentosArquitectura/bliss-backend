using Bliss.API.Promotions.Domain.Model.Aggregates;
using Bliss.API.Promotions.Domain.Model.Repositories;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace Bliss.API.Promotions.Infrastructure.Repositories;

public class PromotionRepository(AppDbContext context) : BaseRepository<Promotion>(context), IPromotionRepository
{

}