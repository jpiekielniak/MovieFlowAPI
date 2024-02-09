using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.CreatedAt;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.UpdatedAt;

namespace MovieFlow.Shared.Abstractions.Kernel;

public abstract class Entity
{
    public Guid Id { get; init; }
    public DateTimeOffset CreatedAt { get; init; } 
    public DateTimeOffset? UpdatedAt { get; set; } = default;
    public EntityState State { get; set; }
}