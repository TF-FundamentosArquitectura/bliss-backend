using Mysqlx.Crud;

namespace NRG3.Bliss.API.ReviewManagement.Domain.Model.Aggregates;
using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

public partial class Review :  IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")]
    public DateTimeOffset? CreatedDate { get; set; }
    [Column("UpdatedAt")]
    public DateTimeOffset? UpdatedDate { get; set; }
}