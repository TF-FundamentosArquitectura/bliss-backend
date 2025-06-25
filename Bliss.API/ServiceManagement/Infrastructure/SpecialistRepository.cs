
using Bliss.API.Domain.Specialists;
using Microsoft.EntityFrameworkCore;
using NRG3.Bliss.API.Shared.Domain.Repositories;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Repositories;
namespace NRG3.Bliss.API.ServiceManagement.Domain.Repositories;

public class SpecialistRepository(AppDbContext context) : BaseRepository<Specialist>(context), ISpecialistRepository
{
    public async Task<string[]> FindByServiceIdAsync(int serviceId)
    {
        var specialist = await Context.Set<Specialist>().Where(s => s.ServiceId == serviceId).ToListAsync();
        return specialist.Select(s => s.Name).ToArray();
    }
}