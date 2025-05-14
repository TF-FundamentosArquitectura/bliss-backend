
using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.IAM.Application.Internal.OutboundServices;
using NRG3.Bliss.API.IAM.Domain.Model.Aggregates;
using NRG3.Bliss.API.IAM.Domain.Model.Commands;
using NRG3.Bliss.API.IAM.Domain.Services;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.IAM.Application.Internal.CommandServices;

public class UserCommandService(
    IUserRepository userRepository,
    IUnitOfWork unitOfWork,
    ITokenService tokenService,
    IHashingService hashingService
) : IUserCommandService
{
    
    public async Task Handle(SignUpCommand command)
    {
        if (userRepository.ExistsByEmail(command.Email))
        {
            throw new Exception($"Username {command.Email} already exists");
        }
            
        var hashedPassword = hashingService.HashPassword(command.Password);
        var user = new User(command, hashedPassword);
        try
        {
            await userRepository.AddAsync(user);
            await unitOfWork.CompleteAsync();
        }
        catch (Exception e)
        {
            throw new Exception($"An error occurred while creating the user: {e.Message}");
        }
    }
    
    public async Task<(User user, string token)> Handle(SignInCommand command)
    {
        var user = await userRepository.FindByEmailAsync(command.Email);

        if (user is null)
        {
            throw new Exception($"User {command.Email} not found");
        }

        if (!hashingService.VerifyPassword(command.Password, user.PasswordHash))
        {
            throw new Exception("Invalid password");
        }
            
        var token = tokenService.GenerateToken(user);
        return (user, token);
    }
}