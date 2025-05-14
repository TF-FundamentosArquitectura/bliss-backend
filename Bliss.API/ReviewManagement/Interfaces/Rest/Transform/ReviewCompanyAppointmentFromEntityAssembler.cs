// ReviewCompanyAppointmentFromEntityAssembler.cs
using NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Resources;
using NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;
using NRG3.Bliss.API.Shared.Interfaces.REST.Resources;

namespace NRG3.Bliss.API.AppointmentManagement.Interfaces.Rest.Transform;


/// <summary>
/// Assembler to create a SimplifiedCompanyResource from a Company entity
/// </summary>
public static class ReviewCompanyAppointmentFromEntityAssembler
{
    /// <summary>
    /// Assembles a SimplifiedCompanyResource from a Company entity
    /// </summary>
    /// <param name="company">
    /// The <see cref="Company"/> entity to assemble the resource from
    /// </param>
    /// <returns>
    /// The <see cref="SimplifiedCompanyResource"/> resource assembled from the entity
    /// </returns>
    public static SimplifiedCompanyResource ToResourceFromEntity(Company company)
    {
        return new SimplifiedCompanyResource(
            company.Id,
            company.Name
        );
    }
}