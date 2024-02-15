namespace MovieFlow.Shared.Abstractions.Kernel;

public abstract class Entity
{
    public Guid Id { get; } = Guid.NewGuid();
    public DateTimeOffset CreatedAt { get; init; } 
    public DateTimeOffset? UpdatedAt { get; set; } = default;
    public EntityState State { get; set; }
}