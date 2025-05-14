using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;

/**
 * Company entity
 * <summary>
 * This class represents the company entity.
 * It contains the properties and methods to manage the company information.
 * </summary>
 */
public partial class Company
{
    public int Id { get; set; }

    public string Name { get; set; }

    public string Ruc { get; set; }

    public string Email { get; set; }

    public string WebsiteUrl { get; set; }

    public string PhoneNumber { get; set; }
    
    public string Description { get; set; }
    public ICollection<Service> Services { get; }
    
    //TODO: Correct this relationship (Astonitas)
    public ICollection<Appointment> Appointments { get; }
    
    public Company()
    {
        Name = string.Empty;
        Ruc = string.Empty;
        Email = string.Empty;
        WebsiteUrl = string.Empty;
        PhoneNumber = string.Empty;
        Description = string.Empty;
    }

    public Company(string name, string ruc, string email, string websiteUrl, string phoneNumber, string description)
    {
        Name = name;
        Ruc = ruc;
        Email = email;
        WebsiteUrl = websiteUrl;
        PhoneNumber = phoneNumber;
        Description = description;
    }
    
    public Company(CreateCompanyCommand command)
    {
        Name = command.Name;
        Ruc = command.Ruc;
        Email = command.Email;
        WebsiteUrl = command.WebsiteUrl;
        PhoneNumber = command.PhoneNumber;
        Description = command.Description;
    }

}