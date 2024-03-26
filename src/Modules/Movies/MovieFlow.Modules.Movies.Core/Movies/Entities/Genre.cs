using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Name;

namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal sealed class Genre : Entity
{
    internal Name Name { get; private set; }
    internal ICollection<Movie> Movies { get; private set; }

    private Genre()
    {
    }

    private Genre(Name name)
    {
        Name = name;
        Movies = [];
        State = EntityState.Added;
    }

    public static Genre Create(Name name) => new(name);
}