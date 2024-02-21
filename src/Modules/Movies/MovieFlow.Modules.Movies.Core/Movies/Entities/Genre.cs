using MovieFlow.Shared.Abstractions.Kernel;

namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal sealed class Genre : Entity
{
    internal string Name { get; private set; }
    internal ICollection<Movie> Movies { get; set; } = new List<Movie>();

    private Genre()
    {
    }

    private Genre(string name)
    {
        Name = name;
        State = EntityState.Added;
    }

    public static Genre Create(string name) => new(name);
}