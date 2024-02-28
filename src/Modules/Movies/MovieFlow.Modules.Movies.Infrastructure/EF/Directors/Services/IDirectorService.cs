using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Directors.Services;

internal interface IDirectorService
{
    IQueryable<DirectorReadModel> FilterByName(IQueryable<DirectorReadModel> directors, string name);
    IQueryable<DirectorReadModel> FilterByDateOfBirth(IQueryable<DirectorReadModel> directors, DateTime? dateOfBirth);
    IQueryable<DirectorReadModel> FilterByCountry(IQueryable<DirectorReadModel> directors, string country);
}