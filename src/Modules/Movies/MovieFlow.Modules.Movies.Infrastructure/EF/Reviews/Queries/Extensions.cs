using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetByMovie.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Reviews.Queries;

internal static class Extensions
{
    public static ReviewDto AsDto(this ReviewReadModel review)
        => new(
            review.Title,
            review.Content,
            review.Rating,
            review.PositiveLikes,
            review.NegativeLikes,
            review.UserId);
}