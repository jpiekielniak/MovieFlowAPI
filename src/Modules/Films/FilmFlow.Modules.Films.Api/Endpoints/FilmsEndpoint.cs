using FilmFlow.Modules.Films.Api.Common.Endpoints;

namespace FilmFlow.Modules.Films.Api.Endpoints;

internal static class FilmsEndpoint
{
    internal const string Url = $"{Routing.BaseUrl}/films";
    internal const string Tag = "Films";
    internal const string Policy = "Films";
}