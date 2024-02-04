using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.CreatedAt;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.UpdatedAt;

namespace MovieFlow.Shared.Abstractions.Kernel;

public abstract class Entity
{
    public Guid Id { get; init; }
    public CreatedAt CreatedAt { get; init; }
    public UpdatedAt? UpdatedAt { get; set; } = default;
    public EntityState State { get; set; }
}