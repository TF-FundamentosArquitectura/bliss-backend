namespace NRG3.Bliss.API.IAM.Domain.Model.Commands;


public record SignUpCommand(
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