using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Reviews;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Shared.Abstractions.Contexts;

namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.DeleteReview;

internal sealed class DeleteReviewHandler(IContext context,
    IMovieRepository movieRepository, IReviewRepository reviewRepository) 
    : IRequestHandler<DeleteReviewCommand>
{
    public async Task Handle(DeleteReviewCommand command, CancellationToken cancellationToken)
    {
        await movieRepository.GetAsync(command.MovieId, cancellationToken)
            .NotNull(() => new MovieNotFoundException(command.MovieId));

        var review = await reviewRepository.GetAsync(command.ReviewId, cancellationToken)
            .NotNull(() => new ReviewNotFoundException(command.ReviewId));

        if (!IsReviewBelongToMovie(review, command.MovieId))
            throw new ReviewDoesNotBelongToMovieException();

        if (!IsReviewBelongToUser(review))
            throw new ReviewDoesNotBelongToUserException(context.Identity.Id);

        await reviewRepository.DeleteAsync(review, cancellationToken);
    }

    private bool IsReviewBelongToUser(Review review)
        => review.UserId == context.Identity.Id;

    private static bool IsReviewBelongToMovie(Review review, Guid movieId)
        => review.MovieId == movieId;
}