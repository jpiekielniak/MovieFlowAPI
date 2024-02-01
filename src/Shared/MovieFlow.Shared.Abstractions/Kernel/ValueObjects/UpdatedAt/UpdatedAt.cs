namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.UpdatedAt;

public class UpdatedAt(DateTimeOffset value) : ValueObject
{
    public DateTimeOffset Value { get; } = value;


    public static implicit operator UpdatedAt(DateTimeOffset value) =>  new (value);
    public static implicit operator DateTimeOffset(UpdatedAt value) => value.Value;
}
