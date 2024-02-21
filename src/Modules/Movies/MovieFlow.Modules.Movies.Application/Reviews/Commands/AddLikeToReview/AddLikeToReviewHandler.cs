using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Reviews;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Shared.Abstractions;
using MovieFlow.Shared.Abstractions.Contexts;

namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.AddLikeToReview;

internal sealed class AddLikeToReviewHandler(
    IMovieRepository movieRepository,
    IReviewRepository reviewRepository,
    ILikeRepository likeRepository,
    IContext context) : IRequestHandler<AddLikeToReviewCommand>
{
    public async Task Handle(AddLikeToReviewCommand command, CancellationToken cancellationToken)
    {
        await movieRepository.GetAsync(command.MovieId, cancellationToken)
            .NotNull(() => new MovieNotFoundException(command.MovieId));

        var review = await reviewRepository.GetAsync(command.ReviewId, cancellationToken)
            .NotNull(() => new ReviewNotFoundException(command.ReviewId));

        var existingLike = review.Likes.Any(x => x.UserId == context.Identity.Id);

        if (existingLike)
            throw new LikeForReviewAlreadyExistsException(context.Identity.Id);

        var like = Like.Create(
            review,
            context.Identity.Id,
            command.IsPositive);

        await likeRepository.AddAsync(like, cancellationToken);
    }
}