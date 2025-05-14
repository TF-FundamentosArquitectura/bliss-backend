namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;

//TODO: move this resource and related assemblers to the shared context (Astonitas)
/// <summary>
/// Simplified Resource for a service
/// </summary>
/// <param name="Id">
/// The unique identifier of the service
/// </param>
/// <param name="ServiceName">
/// The name of the service
/// </param>
/// <param name="Price">
/// The price of the service
/// </param>
public record SimplifiedServiceResource(int Id, string ServiceName, double Price);