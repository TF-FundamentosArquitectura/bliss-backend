
using Bliss.API.Domain.Specialists;
using NRG3.Bliss.API.Shared.Domain.Repositories;
namespace NRG3.Bliss.API.ServiceManagement.Domain.Repositories;

public interface ISpecialistRepository : IBaseRepository<Specialist>
{
    Task<string[]> FindByServiceIdAsync(int serviceId);
}