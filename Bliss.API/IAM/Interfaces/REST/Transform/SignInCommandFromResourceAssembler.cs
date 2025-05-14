using NRG3.Bliss.API.IAM.Domain.Model.Commands;
using NRG3.Bliss.API.IAM.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.IAM.Interfaces.REST.Transform;

public class SignInCommandFromResourceAssembler
{
    public static SignInCommand ToCommandFromResource(SignInResource signInResource)
    {
        return new SignInCommand(
            signInResource.Email,
            signInResource.Password
            );
    }
}