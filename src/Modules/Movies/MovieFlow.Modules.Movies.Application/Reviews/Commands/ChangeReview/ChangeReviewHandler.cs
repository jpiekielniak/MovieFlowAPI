using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Reviews;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Shared.Abstractions;
using MovieFlow.Shared.Abstractions.Contexts;

namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.ChangeReview;

internal sealed class ChangeReviewHandler(
    IMovieRepository movieRepository,
    IReviewRepository reviewRepository,
    IContext context) : IRequestHandler<ChangeReviewCommand>
{
    public async Task Handle(ChangeReviewCommand command, CancellationToken cancellationToken)
    {
        await movieRepository.GetAsync(command.MovieId, cancellationToken)
            .NotNull(() => new MovieDoesNotExistException(command.MovieId));

        var review = await reviewRepository.GetAsync(command.ReviewId, cancellationToken)
            .NotNull(() => new ReviewNotFoundException(command.ReviewId));

        if (!IsReviewBelongToCurrentUser(review))
            throw new ReviewDoesNotBelongToUserException(command.ReviewId);

        review.Change(command.Title, command.Content, command.Rating);

        await reviewRepository.UpdateAsync(review, cancellationToken);
    }

    private bool IsReviewBelongToCurrentUser(Review review)
        => review.UserId == context.Identity.Id;
}