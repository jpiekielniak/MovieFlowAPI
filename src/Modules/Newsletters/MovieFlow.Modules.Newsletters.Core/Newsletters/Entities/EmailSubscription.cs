using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Email;

namespace MovieFlow.Modules.Newsletters.Core.Newsletters.Entities;

internal sealed class EmailSubscription
{
    public Guid Id { get; init; } = Guid.NewGuid();
    public Email Email { get; init; }
    private DateTimeOffset CreatedAt { get; init; } = DateTimeOffset.UtcNow;

    private EmailSubscription()
    {
    }

    private EmailSubscription(string email) => Email = email;

    public static EmailSubscription Create(string email) => new(email);
}