using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.LastName.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.LastName;

public class LastName : ValueObject
{
    private const int MinLastNameLength = 3;
    private const int MaxLastNameLength = 100;
    
    public string Value { get; }

    public LastName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidLastNameException(value);
        
        if(value.Length is < MinLastNameLength or > MaxLastNameLength)
            throw new InvalidLastNameException(value);
        
        Value = value.Trim();
    }
    
    public static implicit operator string(LastName lastName) => lastName.Value;
    public static implicit operator LastName(string lastName) => new(lastName);
}