namespace NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;

public record CreateServiceCommand(int CompanyId, int CategoryId, string ServiceName, string Description, double Price, double Duration, string ImageUrl);