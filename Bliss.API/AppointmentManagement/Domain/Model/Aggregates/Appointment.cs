using System.Runtime.InteropServices.JavaScript;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Commands;
using NRG3.Bliss.API.IAM.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;

namespace NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;

/// <summary>
/// Appointment aggregate root
/// </summary>
/// <remarks>
/// This class represents the appointment aggregate root.
/// It contains the properties and methods to manage the appointment information.
/// </remarks>

//TODO: Match with database  (Astonitas)
public partial class Appointment
{
    public int Id { get; }
    
    public int UserId { get; internal set; }
    public User User { get; internal set; }
    
    //TODO: Remove Company from class (Astonitas)
    public int CompanyId { get; set; }
    public Company Company { get; internal set; }
    
    public int ServiceId { get; set; }
    public Service Service { get; internal set; }
    
    //TODO: Remove RegisterAt from class (Astonitas)
    public DateTime RegisterAt { get; internal set; }
    
    //TODO: Change attribute type to enum (Astonitas)
    public string Status { get; set; }
    public DateTime ReservationDate { get; set; }
    
    //TODO: Change attribute type to DateTime or Time (Astonitas)
    public string ReservationStartTime { get; set; }
    
    public string Requirements { get; set; }

    public Appointment()
    {
        
    }

    public Appointment(CreateAppointmentCommand command)
    {
        UserId = command.UserId;
        CompanyId = command.CompanyId;
        ServiceId = command.ServiceId;
        Status = command.Status;
        ReservationDate = command.ReservationDate;
        ReservationStartTime = command.ReservationStartTime;
        Requirements = command.Requirements;
    }
    
    
}