using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsGroupedByRating;
using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsGroupedByRating.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Context;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Reviews.Queries.GetReviewsGroupedByRating;

internal sealed class GetReviewsGroupedByRatingHandler(MoviesReadDbContext moviesReadDbContext)
    : IRequestHandler<GetReviewsGroupedByRatingQuery, List<GroupedReviewsDto>>
{
    public async Task<List<GroupedReviewsDto>> Handle(GetReviewsGroupedByRatingQuery query,
        CancellationToken cancellationToken)
    {
        var reviews = await moviesReadDbContext.Reviews
            .AsNoTracking()
            .Where(x => x.MovieId == query.MovieId)
            .GroupBy(x => x.Rating)
            .Select(x => new { Rating = x.Key, Count = x.Count() })
            .ToDictionaryAsync(x => x.Rating, x => x.Count, cancellationToken);

        return Enumerable.Range(0, 11)
            .Select(rating =>
                new GroupedReviewsDto(rating, reviews.TryGetValue(rating, out var review) ? review : 0))
            .ToList();
    }
}