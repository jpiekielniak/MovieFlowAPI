using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Movies;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Shared.Abstractions;
using MovieFlow.Shared.Abstractions.Contexts;

namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.AddReview;

internal sealed class AddReviewHandler(IContext context,
    IMovieRepository movieRepository, IReviewRepository reviewRepository) 
    : IRequestHandler<AddReviewCommand, AddReviewResponse>
{
    public async Task<AddReviewResponse> Handle(AddReviewCommand command,
        CancellationToken cancellationToken)
    {
        var movie = await movieRepository.GetAsync(command.MovieId, cancellationToken)
            .NotNull(() => new MovieNotFoundException(command.MovieId));

        var review = Review.Create(
            command.Title,
            command.Content,
            command.Rating,
            movie,
            context.Identity.Id);

        await reviewRepository.AddAsync(review, cancellationToken);
        return new AddReviewResponse(review.Id);
    }
}