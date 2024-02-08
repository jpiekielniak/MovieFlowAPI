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

    private Director(FirstName firstName, LastName lastName,
        DateTime dateOfBirth, Country country)
    {
        Id = Guid.NewGuid();
        FirstName = firstName;
        LastName = lastName;
        DateOfBirth = dateOfBirth;
        Country = country;
    }

    public static Director Create(FirstName firstName, LastName lastName,
        DateTime dateOfBirth, Country country)
        => new(firstName, lastName, dateOfBirth, country);
}