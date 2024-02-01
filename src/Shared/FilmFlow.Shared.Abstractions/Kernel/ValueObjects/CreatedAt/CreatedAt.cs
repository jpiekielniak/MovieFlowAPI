namespace FilmFlow.Shared.Abstractions.Kernel.ValueObjects.CreatedAt;

public class CreatedAt(DateTime value) : ValueObject
{
    public DateTime Value { get; } = value;

    public static implicit operator CreatedAt(DateTime value) =>  new (value);
    public static implicit operator DateTime(CreatedAt value) => value.Value;
}