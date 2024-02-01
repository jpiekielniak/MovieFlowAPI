using MovieFlow.Modules.Movies.Application.Movies.Queries.Browse.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Queries;

internal static class Extensions
{
    public static MovieDto AsMovieDto(this MovieReadModel Movie)
        => new(
            Movie.Id,
            Movie.Title,
            Movie.ReleaseYear,
            Movie.Rating,
            Movie.Description);
}