
using NRG3.Bliss.API.IAM.Domain.Model.Aggregates;
using NRG3.Bliss.API.IAM.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.IAM.Interfaces.REST.Transform;

public class AuthenticatedUserResourceFromEntityAssembler
{
    public static AuthenticatedUserResource ToResourceFromEntity(User user, string token)
    {
        return new AuthenticatedUserResource(user.Id, user.Email, token);
    }
}