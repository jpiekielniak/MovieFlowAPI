
using MediatR;

namespace FilmFlow.Modules.Films.Application.Films.Commands.Create;

internal record CreateFilmCommand(
    string Title,
    string Description,
    double Rating,
    int ReleaseYear) : IRequest<CreateFilmResponse>;