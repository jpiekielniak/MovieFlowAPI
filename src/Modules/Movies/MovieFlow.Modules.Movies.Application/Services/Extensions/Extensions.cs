using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Shared.DTO;

namespace MovieFlow.Modules.Movies.Application.Services.Extensions;

internal static class Extensions
{
    public static ReviewUserDto AsDto(this Review review) =>
        new(review.Id,
            review.Title,
            review.Content,
            review.Rating,
            review.Likes.Count(x => x.IsPositive),
            review.Likes.Count(x => !x.IsPositive),
            review.MovieId);
}