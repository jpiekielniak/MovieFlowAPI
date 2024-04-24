using MovieFlow.Modules.Movies.Core.Movies.Exceptions.Shared;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Country;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.FirstName;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.LastName;

namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal class Actor : Entity
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public DateTime DateOfBirth { get; private set; }
    public Country Country { get; private set; }
    public ICollection<Photo> Photos { get; private set; }
    public ICollection<Movie> Movies { get; private set; }
    
    public uint Age => (uint)DateTime.Now.Year - (uint)DateOfBirth.Date.Year;

    private Actor()
    {
    }

    private Actor(FirstName firstName, LastName lastName, DateTime dateOfBirth, Country country)
    {
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Country = country;
        Photos = new List<Photo>();
        Movies = new List<Movie>();
    }

    public static Actor Create(FirstName firstName, LastName lastName, DateTime dateOfBirth, Country country)
        => new(firstName, lastName, dateOfBirth, country);

    public void AddPhoto(Photo photo) => Photos.Add(photo ?? throw new PhotoCannotBeNullException());
}