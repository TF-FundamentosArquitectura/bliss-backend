namespace NRG3.Bliss.API.ServiceManagement.Interfaces.REST.Resources;

/**
 * Represents a company resource.
 * <param name="Id">
 * The unique identifier of the company.
 * </param>
 * <param name="Name">
 * The name of the company.
 * </param>
 * <param name="Ruc">
 * The RUC of the company.
 * </param>
 * <param name="Email">
 * The email of the company.
 * </param>
 * <param name="WebsiteUrl">
 * The website URL of the company.
 * </param>
 * <param name="PhoneNumber">
 * The phone number of the company.
 * </param>
 * <param name="Description">
 * The description of the company.
 * </param>
 */
public record CompanyResource(int Id, string Name, string Ruc, string Email, string WebsiteUrl, string PhoneNumber, string Description);