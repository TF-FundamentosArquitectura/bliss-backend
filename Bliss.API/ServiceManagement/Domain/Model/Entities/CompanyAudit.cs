using System.ComponentModel.DataAnnotations.Schema;

namespace NRG3.Bliss.API.ServiceManagement.Domain.Model.Entities;

public partial class Company
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; }
}