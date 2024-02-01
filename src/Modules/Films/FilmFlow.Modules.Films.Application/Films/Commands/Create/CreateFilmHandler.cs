using FilmFlow.Modules.Films.Core.Films.Entities;
using FilmFlow.Modules.Films.Core.Films.Repositories;
using FilmFlow.Shared.Abstractions.Time;
using MediatR;

namespace FilmFlow.Modules.Films.Application.Films.Commands.Create;

internal sealed class CreateFilmHandler(
    IFilmRepository filmRepository,
    IClock clock
    ) : IRequestHandler<CreateFilmCommand, CreateFilmResponse>
{
    public async Task<CreateFilmResponse> Handle(CreateFilmCommand command, 
        CancellationToken cancellationToken)
    {
       var filmExist = await filmRepository
           .FilmExistsAsync(command.Title, command.ReleaseYear, cancellationToken);
       
       if(filmExist)
           throw new FilmAlreadyExistsException(command.Title);

       var film = Film.Create(
           command.Title,
           command.Description,
           command.ReleaseYear,
           command.Rating,
           clock.CurrentDateTimeOffset()
           );
       
       await filmRepository.AddAsync(film, cancellationToken);

       return new CreateFilmResponse(film.Id);
    }
}