using MovieFlow.Shared.Abstractions.Kernel;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Content;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Likes;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Rating;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Title;

namespace MovieFlow.Modules.Movies.Core.Movies.Entities;

internal sealed class Review : Entity
{
    internal Title Title { get; private set; }
    internal Content Content { get; private set; }
    internal Rating Rating { get; private set; }
    internal Likes Likes { get; private set; }
    internal Guid MovieId { get; }
    internal Movie Movie { get; }
    internal Guid UserId { get; }

    private Review() //For EF
    {
    }

    private Review(Title title, Content content, Rating rating, Movie movie, Guid userId,
        EntityState entityState)
    {
        Title = title;
        Content = content;
        Rating = rating;
        Likes = new Likes();
        Movie = movie;
        UserId = userId;
        State = entityState;
    }

    public static Review Create(Title title, Content content, Rating rating, 
        Movie movie, Guid userId)
        => new(title, content, rating, movie, userId, EntityState.Added);
}