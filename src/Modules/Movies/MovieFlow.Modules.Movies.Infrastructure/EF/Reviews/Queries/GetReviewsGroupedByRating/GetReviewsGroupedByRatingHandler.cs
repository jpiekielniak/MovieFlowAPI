using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsGroupedByRating;
using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsGroupedByRating.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Reviews.Queries.GetReviewsGroupedByRating;

internal sealed class GetReviewsGroupedByRatingHandler(MoviesReadDbContext moviesReadDbContext)
    : IRequestHandler<GetReviewsGroupedByRatingQuery, GetReviewsGroupedByRatingResponse>
{
    public async Task<GetReviewsGroupedByRatingResponse> Handle(GetReviewsGroupedByRatingQuery query,
        CancellationToken cancellationToken)
    {
        var reviews = await moviesReadDbContext.Reviews
            .AsNoTracking()
            .Where(x => x.MovieId == query.MovieId)
            .GroupBy(x => x.Rating)
            .Select(x => new { Rating = x.Key, Count = x.Count() })
            .ToListAsync(cancellationToken);

        var groupedReviews = Enumerable.Range(0, 11)
            .Select(rating =>
                new GroupedReviewsDto(rating, reviews.FirstOrDefault(x => x.Rating == rating)?.Count ?? 0))
            .ToList();

        return new GetReviewsGroupedByRatingResponse(groupedReviews);
    }
}