using System.ComponentModel.DataAnnotations;
using NRG3.Bliss.API.AppointmentManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.IAM.Domain.Model.Aggregates;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Commands;
namespace NRG3.Bliss.API.ReviewManagement.Domain.Model.Aggregates;

/// <summary>
/// Review aggregate root
/// </summary>
/// <remarks>
/// This class represents the reviews aggregate root.
/// It contains the properties and methods to manage the review information.
/// </remarks>

public partial class Review
{
    [Key]
    public int  Id { get; }
    public int UserId { get; internal set; }

    public User User { get; internal set; }
    public int AppointmentId { get; internal set; }

    public Appointment Appointment { get; set; }
    public string Comment { get; private set; }
    public int Rating { get; private set; }

    public string ImageUrl { get; private set; }
   
    public Review(){

    }
    public Review (CreateReviewCommand command)
    {
        UserId = command.UserId;
        AppointmentId = command.AppointmentId;
        Comment = command.Comment;
        Rating = command.Rating;
        ImageUrl = command.ImageUrl;
    }
}


