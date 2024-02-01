using FilmFlow.Shared.Abstractions.Kernel.ValueObjects.Description.Exceptions;

namespace FilmFlow.Shared.Abstractions.Kernel.ValueObjects.Description;

public class Description : ValueObject
{
    private const int MaxDescriptionLength = 1500;
    private const int MinDescriptionLength = 3;
    public string Value { get; }

    public Description(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
            throw new InvalidDescriptionException(value);
        
        if(value.Length is < MinDescriptionLength or > MaxDescriptionLength)
            throw new InvalidDescriptionException(value);
        
        Value = value.Trim();
    }
    
    public static implicit operator string(Description description) => description.Value;
    public static implicit operator Description(string description) => new(description);
}