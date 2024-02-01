using MovieFlow.Modules.Movies.Api.Common.Endpoints;

namespace MovieFlow.Modules.Movies.Api.Endpoints;

internal static class MoviesEndpoint
{
    internal const string Url = $"{Routing.BaseUrl}/movies";
    internal const string Tag = "Movies";
    internal const string Policy = "Movies";
}