using MovieFlow.Modules.Movies.Application.Actors.Queries.GetActor.DTO;
using MovieFlow.Modules.Movies.Application.Directors.Queries.DTO;
using MovieFlow.Modules.Movies.Application.Directors.Queries.GetMoviesForDirector.DTO;
using MovieFlow.Modules.Movies.Application.Shared.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Queries;

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
            director.Photos.Select(x => x.Url).ToList()
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

    public static ActorDetailsDto AsDetailsDto(this ActorReadModel actor)
        => new(
            actor.Id,
            actor.FirstName,
            actor.LastName,
            actor.Age,
            actor.Country,
            actor.Photos.Select(x => x.Url).FirstOrDefault(),
            actor.Movies?.Select(x => x.AsMovieDto()).ToList()
        );
}