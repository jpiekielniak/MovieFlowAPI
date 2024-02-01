namespace FilmFlow.Shared.Abstractions.Kernel.ValueObjects.CreatedAt;

public class CreatedAt(DateTimeOffset value) : ValueObject
{
    public DateTimeOffset Value { get; } = value;

    public static implicit operator CreatedAt(DateTimeOffset value) =>  new (value);
    public static implicit operator DateTimeOffset(CreatedAt value) => value.Value;
}