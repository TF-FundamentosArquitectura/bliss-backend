using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;

/**
 * Service aggregate root entity
 * <summary>
 *  This class represents the service aggregate root.
 *  It contains the properties and methods to manage the service information.
 * </summary>
 */
public partial class Service
{
    public int Id { get; }
    public int CompanyId { get; private set; }
    public Company Company { get; internal set; }
    public int CategoryId { get; private set; }
    public Category Category { get; internal set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public double Price { get; private set; }
    public double Duration { get; private set; }
    public string ImageUrl { get; private set; }
    public double Rating { get; private set; }
    public int Sales { get; private set; }
    
    public ICollection<Appointment> Appointments { get; }

    public Service(int companyId, int categoryId, string name, string description, double price, double duration, string imageUrl)
    {
        CompanyId = companyId;
        CategoryId = categoryId;
        Name = name;
        Description = description;
        Price = price;
        Duration = duration;
        ImageUrl = imageUrl;
        Rating = 0;
        Sales = 0;
    }

    public void UpdateInformation(string serviceName, string description, double price, double duration)
    {
        Name = serviceName;
        Description = description;
        Price = price;
        Duration = duration;
    }
}