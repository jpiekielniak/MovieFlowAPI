namespace MovieFlow.Modules.Movies.Application.Movies.Queries.BrowseMovies.DTO;

internal record MovieDto(Guid Id, string Title, List<string> Genres, string PhotoUrl);