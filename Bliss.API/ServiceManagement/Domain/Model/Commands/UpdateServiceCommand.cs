namespace NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;

public record UpdateServiceCommand(int ServiceId, int CategoryId, string ServiceName, string Description, double Price, double Duration);