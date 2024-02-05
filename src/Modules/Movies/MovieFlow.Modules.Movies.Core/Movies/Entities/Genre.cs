using MovieFlow.Shared.Abstractions.Kernel;

namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal sealed class Genre : Entity
{
    internal string Name { get; private set; }
    internal ICollection<Movie> Movies { get;  set; }

    private Genre() //for EF
    {
    }
}