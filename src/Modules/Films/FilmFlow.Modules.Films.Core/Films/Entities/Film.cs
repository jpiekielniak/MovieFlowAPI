using FilmFlow.Shared.Abstractions.Kernel.ValueObjects.CreatedAt;
using FilmFlow.Shared.Abstractions.Kernel.ValueObjects.Description;
using FilmFlow.Shared.Abstractions.Kernel.ValueObjects.Rating;
using FilmFlow.Shared.Abstractions.Kernel.ValueObjects.ReleaseYear;
using FilmFlow.Shared.Abstractions.Kernel.ValueObjects.Title;
using FilmFlow.Shared.Abstractions.Kernel.ValueObjects.UpdatedAt;

namespace FilmFlow.Modules.Films.Core.Films.Entities;

internal sealed class Film
{
    public Guid Id { get; init; }
    internal Title Title { get;  private set; }
    internal Description Description { get; private set; }
    internal ReleaseYear ReleaseYear { get; private set; }
    internal Rating Rating { get; private set; }
    private CreatedAt CreatedAt { get; init; }
    private UpdatedAt? UpdatedAt { get; set; } = default;

    private Film() // for EF
    {
    }

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