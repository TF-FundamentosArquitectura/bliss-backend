using NRG3.Bliss.API.AppointmentManagement.Domain.Repositories;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Aggregates;
using NRG3.Bliss.API.ReviewManagement.Domain.Model.Commands;
using NRG3.Bliss.API.ReviewManagement.Domain.Repositories;
using NRG3.Bliss.API.ReviewManagement.Domain.Services;
using NRG3.Bliss.API.Shared.Domain.Repositories;

namespace NRG3.Bliss.API.ReviewManagement.Application.Internal.CommandServices;

/// <summary>
/// Review command service
/// </summary>
/// <param name="reviewRepository">
/// Review repository
/// </param>
/// <param name="userRepository">
/// User repository
/// </param>
/// <param name="appointmentRepository">
/// Appointment repository
/// </param>
/// <param name="unitOfWork">
/// Unit of work
/// </param>
public class ReviewCommandService(
    IReviewRepository reviewRepository,
    IUserRepository userRepository,
    IAppointmentRepository appointmentRepository,
    IUnitOfWork unitOfWork)
    : IReviewCommandService
{
    /// <inheritdoc />
    public async Task<Review?> Handle(CreateReviewCommand command)
    {
        var user = await userRepository.FindByIdAsync(command.UserId);
        var appointment = await appointmentRepository.FindByIdAsync(command.AppointmentId);

        if (user == null || appointment == null)
        {
            throw new InvalidOperationException("Invalid user or appointment.");
        }

        // Check if the appointment already has a review
        
        if (await reviewRepository.ReviewExistForAppointmentId(command.AppointmentId))
        {
            throw new InvalidOperationException("The appointment already has a review.");
        }


        var review = new Review(command);
        await reviewRepository.AddAsync(review);
        await unitOfWork.CompleteAsync();
        return review;
    }

    /// <inheritdoc />
    public async Task Handle(DeleteReviewCommand command)
    {
        var review = await reviewRepository.FindReviewByIdAsync(command.reviewId);
        if (review != null)
        {
            reviewRepository.Remove(review);
            await unitOfWork.CompleteAsync();
        }
    }

    /// <inheritdoc />
    public async Task<Review?> Handle(UpdateReviewCommand command)
    {
        var review = await reviewRepository.FindReviewByIdAsync(command.ReviewId);
        if (review != null)
        {
            // Update properties here
            await unitOfWork.CompleteAsync();
        }
        return review;
    }
}