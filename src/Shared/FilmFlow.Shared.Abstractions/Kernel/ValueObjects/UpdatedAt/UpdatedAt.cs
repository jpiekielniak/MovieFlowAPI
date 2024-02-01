namespace FilmFlow.Shared.Abstractions.Kernel.ValueObjects.UpdatedAt;

public class UpdatedAt(DateTime value) : ValueObject
{
    public DateTime Value { get; } = value;


    public static implicit operator UpdatedAt(DateTime value) =>  new (value);
    public static implicit operator DateTime(UpdatedAt value) => value.Value;
}
