using Microsoft.EntityFrameworkCore;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.ServiceManagement.Domain.Repositories;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NRG3.Bliss.API.ServiceManagement.Infrastructure.Persistence.EFC.Repositories;

public class CompanyRepository(AppDbContext context) : BaseRepository<Company>(context), ICompanyRepository
{
    /// <inheritdoc />
    public async Task<IEnumerable<Company>> FindCompaniesByCompanyName(string name)=> 
        await Context.Set<Company>()
        .Where(c => c.Name == name)
        .ToListAsync();
    
}