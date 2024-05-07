using MovieFlow.Modules.Movies.Application.Directors.Queries.DTO;
using MovieFlow.Modules.Movies.Application.Directors.Queries.GetMoviesForDirector.DTO;
using MovieFlow.Modules.Movies.Application.Shared.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Directors.Queries;

internal static class Extensions
{
    public static DirectorDetailsDto AsDetailsDto(this DirectorReadModel director)
        => new(
            director.Id,
            director.FirstName,
            director.LastName,
            director.DateOfBirth,
            director.Country,
            director.Photos.SingleOrDefault()?.Url
        );

    public static DirectorDto AsDto(this DirectorReadModel director)
        => new(
            director.Id,
            director.FirstName,
            director.LastName,
            director.Photos.Select(x => x.Url).FirstOrDefault()
        );

    public static DirectorMovieDto AsDirectorMovieDto(this MovieReadModel movie)
        => new(movie.Id, movie.Title);
}