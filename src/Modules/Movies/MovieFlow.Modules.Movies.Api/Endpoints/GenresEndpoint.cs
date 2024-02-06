using MovieFlow.Modules.Movies.Api.Common.Endpoints;

namespace MovieFlow.Modules.Movies.Api.Endpoints;

internal static class GenresEndpoint
{
    internal const string Url = $"{Routing.BaseUrl}/genres";
    internal const string Tag = "Genres";
    internal const string Policy = "Genres";
}