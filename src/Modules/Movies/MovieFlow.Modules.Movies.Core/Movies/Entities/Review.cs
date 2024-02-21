using MovieFlow.Shared.Abstractions.Kernel;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Content;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Rating;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Title;

namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal sealed class Review : Entity
{
    internal Title Title { get; private set; }
    internal Content Content { get; private set; }
    internal Rating Rating { get; private set; }
    internal ICollection<Like> Likes { get; } = new List<Like>();
    internal int PositiveLikes => Likes.Count(x => x.IsPositive);
    internal int NegativeLikes => Likes.Count(x => !x.IsPositive);
    internal Guid MovieId { get; }
    internal Movie Movie { get; }
    internal Guid UserId { get; }

    private Review()
    {
    }

    private Review(Title title, Content content, Rating rating, Movie movie, 
        Guid userId, EntityState entityState)
    {
        Title = title;
        Content = content;
        Rating = rating;
        Movie = movie;
        UserId = userId;
        State = entityState;
    }

    public static Review Create(Title title, Content content, Rating rating,
        Movie movie, Guid userId)
        => new(title, content, rating, movie, userId, EntityState.Added);

    public void Change(Title title, Content content, Rating rating)
    {
        Title = title;
        Content = content;
        Rating = rating;
        State = EntityState.Modified;
    }
}