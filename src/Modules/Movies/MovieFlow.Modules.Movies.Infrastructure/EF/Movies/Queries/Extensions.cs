using MovieFlow.Modules.Movies.Application.Movies.Queries.Browse.DTO;
using MovieFlow.Modules.Movies.Application.Movies.Queries.Get.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Queries;

internal static class Extensions
{
    public static MovieDto AsMovieDto(this MovieReadModel movie)
        => new(
            movie.Id,
            movie.Title,
            movie.Genres.Select(x => x.Name).ToList()
        );

    public static MovieDetailsDto AsMovieDetailsDto(this MovieReadModel movie)
        => new(
            movie.Id,
            movie.Title,
            movie.Rating,
            movie.ReleaseYear,
            movie.Description,
            movie.Genres.Select(x => new GenreNameDto(x.Name)).ToList(),
            movie.Director.AsDirectorDto()
        );

    private static DirectorDto AsDirectorDto(this DirectorReadModel director)
        => new(
            director.Id,
            director.FirstName,
            director.LastName,
            director.DateOfBirth,
            director.Country);
}