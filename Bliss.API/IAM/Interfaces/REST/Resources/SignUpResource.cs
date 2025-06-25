namespace NRG3.Bliss.API.IAM.Interfaces.REST.Resources;

public record SignUpResource(
    // Comunes para ambos
    string Email,
    string Password,
    string Role,

    // Solo para clientes
    string? FirstName = null,
    string? LastName = null,
    string? Phone = null,
    string? Dni = null,
    string? Address = null,
    string? City = null,
    DateTime? BirthDate = null,

    // Solo para empresas
    string? Name = null,
    string? Ruc = null,
    string? WebsiteUrl = null,
    string? PhoneNumber = null,
    string? Description = null
);
