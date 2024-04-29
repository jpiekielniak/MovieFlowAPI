using MovieFlow.Modules.Movies.Application.Actors.Queries.GetActor.DTO;
using MovieFlow.Modules.Movies.Application.Actors.Queries.GetMoviesByActor.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Queries;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Actors.Queries;

internal static class Extensions
{
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

    public static ActorMovieDto AsActorMovieDto(this MovieReadModel movie)
        => new(
            movie.Id,
            movie.Title,
            movie.Photos.Select(x => x.Url).FirstOrDefault()
        );
}