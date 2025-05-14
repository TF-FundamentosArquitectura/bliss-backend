
using System.Net.Mime;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Queries;
using NRG3.Bliss.API.ReviewManagement.Domain.Services;
using NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Resources;
using NRG3.Bliss.API.ReviewManagement.Interfaces.Rest.Transform;
using Swashbuckle.AspNetCore.Annotations;

namespace NRG3.Bliss.API.ReviewManagement.Interfaces.Rest;

[ApiController]
[Route("api/v1/[controller]")]
[Produces(MediaTypeNames.Application.Json)]
[Tags("Reviews")]
public class ReviewsController(
    IReviewCommandService reviewCommandService,
    IReviewQueryService reviewQueryService
    ) : ControllerBase
{
    [HttpGet("{reviewId:int}")]
    [SwaggerOperation(
        Summary = "Get review by id",
        Description = "Get a review by the id it has",
        OperationId = "GetReviewById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The review was found", typeof(ReviewResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The review was not found.")]
    public async Task<IActionResult> GetReviewById([FromRoute] int reviewId)
    {
        var getReviewByIdQuery = new GetReviewByIdQuery(reviewId);
        var review = await reviewQueryService.Handle(getReviewByIdQuery);
        if (review is null) return NotFound();
        var reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return Ok(reviewResource);
    }

    [HttpGet("user/{userId:int}")]
    [SwaggerOperation(
        Summary = "Get reviews by user id",
        Description = "Get the reviews a user has",
        OperationId = "GetReviewsByUserId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The reviews were found", typeof(IEnumerable<ReviewResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The reviews were not found.")]
    public async Task<IActionResult> GetReviewsByUserId([FromRoute] int userId)
    {
        var getAllReviewsByUserIdQuery = new GetAllReviewsByUserIdQuery(userId);
        var reviews = await reviewQueryService.Handle(getAllReviewsByUserIdQuery);
        var reviewResources = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reviewResources);
    }


    [HttpGet("appointment/{appointmentId:int}")]
    [SwaggerOperation(
        Summary = "Get review by appointment id",
        Description = "Get a review by the id the appointment has",
        OperationId = "GetReviewByAppointmentIdQuery")]
    [SwaggerResponse(StatusCodes.Status200OK, "The review was found", typeof(ReviewResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The review was not found.")]
    public async Task<IActionResult> GetReviewByAppointmentId([FromRoute] int appointmentId)
    {
        var getReviewByAppointmentIdQuery = new GetReviewByAppointmentIdQuery(appointmentId);
        var review = await reviewQueryService.Handle(getReviewByAppointmentIdQuery);
        if (review is null) return NotFound();
        var reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return Ok(reviewResource);
    }
    

    [HttpGet("company/{companyId:int}")]
    [SwaggerOperation(
        Summary = "Get reviews by company id",
        Description = "Get the reviews a company has",
        OperationId = "GetReviewsByCompanyId")]
    [SwaggerResponse(StatusCodes.Status200OK, "The reviews were found", typeof(IEnumerable<ReviewResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The reviews were not found.")]
    public async Task<IActionResult> GetReviewsByCompanyId([FromRoute] int companyId)
    {
        var getAllReviewsByCompanyIdQuery = new GetAllReviewsByCompanyIdQuery(companyId);
        var reviews = await reviewQueryService.Handle(getAllReviewsByCompanyIdQuery);
        var reviewResources = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reviewResources);
    }

    [HttpPost]
    [SwaggerOperation(
        Summary = "Create a new review",
        Description = "Create a new review in the system",
        OperationId = "CreateReview")]
    [SwaggerResponse(StatusCodes.Status201Created, "The review was created", typeof(ReviewResource))]
    [SwaggerResponse(StatusCodes.Status400BadRequest, "The review was not created")]
    public async Task<IActionResult> CreateReview([FromBody] CreateReviewResource resource)
    {
        var createReviewCommand = CreateReviewCommandResourceFromEntityAssembler.ToCommandFromResource(resource);
        var review = await reviewCommandService.Handle(createReviewCommand);
        if (review is null) return NotFound();

        var appointment = await reviewQueryService.GetAppointmentByIdAsync(review.AppointmentId);
        if (appointment?.Service == null || appointment.Company == null)
        {
            return BadRequest("Appointment's Service or Company is null");
        }

        var reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return CreatedAtAction(nameof(GetReviewById), new { reviewId = review.Id }, reviewResource);
    }

    [HttpDelete("{reviewId:int}")]
    [SwaggerOperation(
        Summary = "Delete a review by id",
        Description = "Delete a review in the system by its id",
        OperationId = "DeleteReviewById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The review was deleted", typeof(ReviewResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The review was not found.")]
    public async Task<IActionResult> DeleteReviewById([FromRoute] int reviewId)
    {
        var deleteReviewCommand = new DeleteReviewCommand(reviewId);
        await reviewCommandService.Handle(deleteReviewCommand);
        return Ok("The review with the given id was successfully deleted");
    }

    [HttpPut("{reviewId:int}")]
    [SwaggerOperation(
        Summary = "Update a review by id",
        Description = "Update a review in the system by its id",
        OperationId = "UpdateReviewById")]
    [SwaggerResponse(StatusCodes.Status200OK, "The review was updated", typeof(ReviewResource))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "The review was not found.")]
    public async Task<IActionResult> UpdateReviewById([FromRoute] int reviewId, [FromBody] UpdateReviewResource resource)
    {
        var updateReviewCommand = UpdateReviewCommandResourceFromEntityAssembler.ToCommandFromResource(reviewId, resource);
        var review = await reviewCommandService.Handle(updateReviewCommand);
        if (review is null) return NotFound();
        var reviewResource = ReviewResourceFromEntityAssembler.ToResourceFromEntity(review);
        return Ok(reviewResource);
    }
    
    [HttpGet]
    [SwaggerOperation(
        Summary = "Get all reviews",
        Description = "Get all reviews in the system",
        OperationId = "GetAllReviews")]
    [SwaggerResponse(StatusCodes.Status200OK, "The reviews were found", typeof(IEnumerable<ReviewResource>))]
    [SwaggerResponse(StatusCodes.Status404NotFound, "No reviews were found.")]
    public async Task<IActionResult> GetAllReviews()
    {
        var reviews = await reviewQueryService.GetAllReviewsAsync();
        if (!reviews.Any()) return NotFound();
        var reviewResources = reviews.Select(ReviewResourceFromEntityAssembler.ToResourceFromEntity);
        return Ok(reviewResources);
    }
}