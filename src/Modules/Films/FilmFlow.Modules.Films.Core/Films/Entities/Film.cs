using FilmFlow.Shared.Abstractions.Kernel.ValueObjects.CreatedAt;
using FilmFlow.Shared.Abstractions.Kernel.ValueObjects.UpdatedAt;

namespace FilmFlow.Modules.Films.Core.Films.Entities;

internal sealed class Film
{
    public Guid Id { get; init; }
    internal string Title { get;  set; }
    internal string Description { get; set; }
    internal int ReleaseYear { get; set; }
    internal double Rating { get; set; }
    private CreatedAt CreatedAt { get; init; }
    private UpdatedAt? UpdatedAt { get; set; } = default;
    
    private Film(string title, string description, int releaseYear, double rating)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        ReleaseYear = releaseYear;
        Rating = rating;
        CreatedAt = DateTime.UtcNow;
    }
    
    public static Film Create(string title, string description, int releaseYear, double rating)
        => new(title, description, releaseYear, rating);
}