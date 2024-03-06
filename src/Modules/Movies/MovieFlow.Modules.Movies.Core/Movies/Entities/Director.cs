using MovieFlow.Shared.Abstractions.Kernel;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Country;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.FirstName;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.LastName;

namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal class Director : Entity
{
    internal FirstName FirstName { get; set; }
    internal LastName LastName { get; set; }
    internal DateTime DateOfBirth { get; set; }
    internal Country Country { get; set; }
    internal ICollection<Movie> Movies { get; set; }
    internal ICollection<DirectorPhoto> DirectorPhotos { get; set; }

    private Director()
    {
    }

    private Director(FirstName firstName, LastName lastName,
        DateTime dateOfBirth, Country country, EntityState entityState)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Country = country;
        DirectorPhotos = new List<DirectorPhoto>();
        State = entityState;
    }

    public static Director Create(FirstName firstName, LastName lastName,
        DateTime dateOfBirth, Country country)
        => new(firstName, lastName, dateOfBirth, country, EntityState.Added);

    public void ChangeInformation(string firstName, string lastName, DateTime dateOfBirth, string country)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Country = country;
        State = EntityState.Modified;
    }

    public void AddPhoto(Photo photo)
    {
        var directorPhoto = DirectorPhoto.Create(this, photo);
        DirectorPhotos.Add(directorPhoto);
    }
}