using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.CreatedAt;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Description;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Rating;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.ReleaseYear;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Title;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.UpdatedAt;

namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal sealed class Movie
{
    public Guid Id { get; init; }
    internal Title Title { get; private set; }
    internal Description Description { get; private set; }
    internal ReleaseYear ReleaseYear { get; private set; }
    internal Rating Rating { get; private set; }
    private CreatedAt CreatedAt { get; init; }
    private UpdatedAt? UpdatedAt { get; set; } = default;

    private Movie() // for EF
    {
    }

    private Movie(Title title, Description description,
        ReleaseYear releaseYear, Rating rating, CreatedAt createdAt)
    {
        Id = Guid.NewGuid();
        Title = title;
        Description = description;
        ReleaseYear = releaseYear;
        Rating = rating;
        CreatedAt = createdAt;
    }

    public static Movie Create(string title, string description, int releaseYear,
        double rating, DateTimeOffset createdAt)
        => new(title, description, releaseYear, rating, createdAt);

    internal void ChangeInformation(Title title, Description description,
        ReleaseYear releaseYear, Rating rating, UpdatedAt updatedAt)
    {
        Title = title;
        Description = description;
        ReleaseYear = releaseYear;
        Rating = rating;
        UpdatedAt = updatedAt;
    }
}