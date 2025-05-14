namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

/// <summary>
/// Resource for a user
/// </summary>
/// <param name="Id">
/// The unique identifier of the user
/// </param>
/// <param name="FirstName">
/// The first name of the user
/// </param>
/// <param name="LastName">
/// The last name of the user
/// </param>
/// <param name="Email">
/// The email of the user
/// </param>
/// <param name="Phone">
/// The phone of the user
/// </param>
/// <param name="Dni">
/// The dni of the user
/// </param>
/// <param name="Address">
/// The address of the user
/// </param>
/// <param name="City">
/// The city of the user
/// </param>
/// <param name="BirthDate">
/// The birth date of the user
/// </param>
public record UserResource(
    int Id,
    string FirstName,
    string LastName,
    string Email,
    string Phone,
    string Dni,
    string Address,
    string City,
    DateTime BirthDate
    );