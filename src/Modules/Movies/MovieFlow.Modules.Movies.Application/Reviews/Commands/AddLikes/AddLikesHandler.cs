using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Reviews;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Shared.Abstractions;
using MovieFlow.Shared.Abstractions.Contexts;

namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.AddLikes;

internal sealed class AddLikesHandler(
    IMovieRepository movieRepository,
    IReviewRepository reviewRepository,
    ILikeRepository likeRepository,
    IContext context) : IRequestHandler<AddLikesCommand>
{
    public async Task Handle(AddLikesCommand command, CancellationToken cancellationToken)
    {
        await movieRepository.GetAsync(command.MovieId, cancellationToken)
            .NotNull(() => new MovieDoesNotExistException(command.MovieId));

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