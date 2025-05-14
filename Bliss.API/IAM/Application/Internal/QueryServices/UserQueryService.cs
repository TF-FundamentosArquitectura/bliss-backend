
using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.IAM.Domain.Model.Aggregates;
using NRG3.Bliss.API.IAM.Domain.Model.Queries;
using NRG3.Bliss.API.IAM.Domain.Services;

namespace NRG3.Bliss.API.IAM.Application.Internal.QueryServices;

public class UserQueryService(
    IUserRepository userRepository
    ) : IUserQueryService
{
    public async Task<User?> Handle(GetUserByIdQuery query)
    {
        return await userRepository.FindByIdAsync(query.UserId);
    }

    public async Task<IEnumerable<User>> Handle(GetAllUsersQuery query)
    {
        return await userRepository.ListAsync();
    }
}