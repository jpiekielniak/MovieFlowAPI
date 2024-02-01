using MediatR;
using MovieFlow.Modules.Movies.Core.Movies.Entities;
using MovieFlow.Modules.Movies.Core.Movies.Exceptions;
using MovieFlow.Modules.Movies.Core.Movies.Repositories;
using MovieFlow.Shared.Abstractions.Time;

namespace MovieFlow.Modules.Movies.Application.Movies.Commands.Create;

internal sealed class CreateMovieHandler(
    IMovieRepository movieRepository,
    IClock clock
    ) : IRequestHandler<CreateMovieCommand, CreateMovieResponse>
{
    public async Task<CreateMovieResponse> Handle(CreateMovieCommand command, 
        CancellationToken cancellationToken)
    {
       var movieExists = await movieRepository
           .MovieExistsAsync(command.Title, command.ReleaseYear, cancellationToken);
       
       if(movieExists)
           throw new MovieAlreadyExistsException(command.Title);

       var movie = Movie.Create(
           command.Title,
           command.Description,
           command.ReleaseYear,
           command.Rating,
           clock.CurrentDateTimeOffset()
           );
       
       await movieRepository.AddAsync(movie, cancellationToken);

       return new CreateMovieResponse(movie.Id);
    }
}