namespace NRG3.Bliss.API.ServiceManagement.Domain.Model.Commands;

public record CreateCompanyCommand(string Name, string Ruc, string Email, string WebsiteUrl, string PhoneNumber, string Description);