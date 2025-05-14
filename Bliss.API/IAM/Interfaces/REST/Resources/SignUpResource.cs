namespace NRG3.Bliss.API.IAM.Interfaces.REST.Resources;

public record SignUpResource(
    string FirstName,
    string LastName,
    string Password,
    string Email,
    string Phone,
    string Dni,
    string Address,
    string City,
    DateTime BirthDate
    );