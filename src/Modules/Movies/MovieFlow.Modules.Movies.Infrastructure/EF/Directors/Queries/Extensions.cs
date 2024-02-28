using MovieFlow.Modules.Movies.Application.Directors.Queries.DTO;
using MovieFlow.Modules.Movies.Application.Movies.Queries.Get.DTO;
using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Directors.Queries;

internal static class Extensions
{
    public static DirectorDetailsDto AsDetailsDto(this DirectorReadModel director)
        => new(
            director.Id,
            director.FirstName,
            director.LastName,
            director.DateOfBirth,
            director.Country
        );

    public static DirectorDto AsDto(this DirectorReadModel director)
        => new(
            director.Id,
            director.FirstName,
            director.LastName
        );
}