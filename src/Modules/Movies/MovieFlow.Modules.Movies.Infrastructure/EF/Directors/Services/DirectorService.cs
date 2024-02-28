using MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

namespace MovieFlow.Modules.Movies.Infrastructure.EF.Directors.Services;

internal sealed class DirectorService : IDirectorService
{
    public IQueryable<DirectorReadModel> FilterByName(IQueryable<DirectorReadModel> directors, string name)
    {
        if (string.IsNullOrWhiteSpace(name))
            return directors;

        var search = $"%{name}%";
        directors = directors.Where(
            f => Microsoft.EntityFrameworkCore.EF.Functions.ILike(
                f.FirstName + " " + f.LastName, search));

        return directors;
    }

    public IQueryable<DirectorReadModel> FilterByDateOfBirth(IQueryable<DirectorReadModel> directors,
        DateTime? dateOfBirth)
        => dateOfBirth.HasValue ? directors.Where(f => f.DateOfBirth == dateOfBirth.Value) : directors;

    public IQueryable<DirectorReadModel> FilterByCountry(IQueryable<DirectorReadModel> directors, string country)
    {
        if (string.IsNullOrWhiteSpace(country))
            return directors;

        var search = $"%{country}%";
        directors = directors.Where(
            f => Microsoft.EntityFrameworkCore.EF.Functions.ILike(
                f.Country, search));

        return directors;
    }
}