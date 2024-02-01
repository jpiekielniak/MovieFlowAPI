using FilmFlow.Modules.Films.Application.Films.Queries.Browse.DTO;
using MediatR;

namespace FilmFlow.Modules.Films.Application.Films.Queries.Browse;

internal class BrowseFilmsQuery : IRequest<List<FilmDto>>
{
    public string? Title { get; set; }
    public int? ReleaseYear { get; set; }
}