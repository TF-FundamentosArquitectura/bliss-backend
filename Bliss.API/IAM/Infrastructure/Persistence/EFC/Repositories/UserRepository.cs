using Microsoft.EntityFrameworkCore;
using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.IAM.Domain.Model.Aggregates;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Configuration;
using NRG3.Bliss.API.Shared.Infrastructure.Persistence.EFC.Repositories;

namespace NRG3.Bliss.API.IAM.Infrastructure.Persistence.EFC.Repositories;

/// <summary>
/// Repository for the User entity
/// </summary>
/// <param name="context">
/// The database context
/// </param>
public class UserRepository(AppDbContext context): BaseRepository<User>(context), IUserRepository
{
    public bool ExistsByEmail(string email)
    {
        return Context.Set<User>().Any(user => user.Email.Equals(email));
    }

    public async Task<User?> FindByEmailAsync(string email)
    {
        return await Context.Set<User>().FirstOrDefaultAsync(user => user.Email.Equals(email));
    }
}