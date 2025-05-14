using NRG3.Bliss.API.IAM.Domain.Model.Commands;
using NRG3.Bliss.API.IAM.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.IAM.Interfaces.REST.Transform;

public class SignUpCommandFromResourceAssembler
{
    public static SignUpCommand ToCommandFromResource(SignUpResource resource)
    {
        return new SignUpCommand(
            resource.FirstName,
            resource.LastName,
            resource.Password,
            resource.Email,
            resource.Phone,
            resource.Dni,
            resource.Address,
            resource.City,
            resource.BirthDate
            );
    }
}