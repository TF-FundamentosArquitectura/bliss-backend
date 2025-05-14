using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.IAM.Domain.Model.Commands;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Aggregates;

namespace NRG3.Bliss.API.IAM.Domain.Model.Aggregates;

/// <summary>
/// User aggregate root
/// </summary>
/// <remarks>
/// This class represents the user aggregate root.
/// It contains the properties and methods to manage the user information.
/// </remarks>

public partial class User
{
    public int Id { get; private set; }
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string PasswordHash { get; private set; }
    public string Email { get; private set; }
    public string Phone { get; private set; }
    public string Dni { get; private set; }
    public string Address { get; private set; }
    public string City { get; private set; }
    public DateTime BirthDate { get; private set; }
    
    public ICollection<Appointment> Appointments { get; }
    
    public ICollection<Review> Reviews { get; private set; } = new List<Review>();

    
    public User( string firstName, 
        string lastName, 
        string passwordHash, 
        string email, 
        string phone, 
        string dni, 
        string address, 
        string city, 
        DateTime birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        PasswordHash = passwordHash;
        Email = email;
        Phone = phone;
        Dni = dni;
        Address = address;
        City = city;
        BirthDate = birthDate;
    }
    
    public User(SignUpCommand command, string hashedPasswordHash)
    {
        FirstName = command.FirstName;
        LastName = command.LastName;
        PasswordHash = hashedPasswordHash;
        Email = command.Email;
        Phone = command.Phone;
        Dni = command.Dni;
        Address = command.Address;
        City = command.City;
        BirthDate = command.BirthDate;
    }
    
}