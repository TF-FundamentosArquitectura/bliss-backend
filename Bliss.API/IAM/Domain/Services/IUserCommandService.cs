
using NRG3.Bliss.API.IAM.Domain.Model.Aggregates;
using NRG3.Bliss.API.IAM.Domain.Model.Commands;

namespace NRG3.Bliss.API.IAM.Domain.Services;

public interface IUserCommandService
{
    /// <summary>
    /// Handle sign-up command 
    /// </summary>
    /// <param name="command">
    /// The sign-up command
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation
    /// </returns>
    Task Handle(SignUpCommand command);
    
    /// <summary>
    /// Handle sign-in command 
    /// </summary>
    /// <param name="command">
    /// The sign-in command
    /// </param>
    /// <returns>
    /// A task representing the asynchronous operation, containing the <see cref="User"/> user and generated token
    /// </returns>
    Task<(User user, string token)> Handle(SignInCommand command);
}