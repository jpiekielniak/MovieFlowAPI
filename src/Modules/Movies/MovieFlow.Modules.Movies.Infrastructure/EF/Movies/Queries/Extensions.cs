using MovieFlow.Modules.Movies.Application.Movies.Queries.BrowseMovies.DTO;
using MovieFlow.Modules.Movies.Application.Movies.Queries.GetMovie.DTO;
using MovieFlow.Modules.Movies.Application.Shared.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Queries;

internal static class Extensions
{
    public static MovieDto AsMovieDto(this MovieReadModel movie)
        => new(
            movie.Id,
            movie.Title,
            movie.Genres.Select(x => new GenreNameDto(x.Name)).ToList(),
            movie.Photos.SingleOrDefault()?.Url
        );

    public static MovieDetailsDto AsMovieDetailsDto(this MovieReadModel movie)
        => new(
            movie.Id,
            movie.Title,
            movie.Reviews.Any() ? movie.Reviews.Average(x => x.Rating) : 0,
            movie.ReleaseYear,
            movie.Description,
            movie.Genres.Select(x => new GenreNameDto(x.Name)).ToList(),
            movie.Director.AsDirectorDto(),
            movie.Actors.Select(x => x.AsActorDto()).ToList(),
            movie.Photos.Select(x => x.Url).ToList()
        );

    private static DirectorDto AsDirectorDto(this DirectorReadModel director)
        => new(
            director.Id,
            director.FirstName,
            director.LastName,
            director.Photos.SingleOrDefault()?.Url
        );

    private static ActorDto AsActorDto(this ActorReadModel actor)
        => new(
            actor.Id,
            $"{actor.FirstName} {actor.LastName}",
            actor.Photos.SingleOrDefault()?.Url
        );
}