using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.FirstName.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.FirstName;

public class FirstName : ValueObject
{
    private const int MinFirstNameLength = 3;
    private const int MaxFirstNameLength = 100;
    public string Value { get; }
    

    public FirstName(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidFirstNameException(value);
        
        if(value.Length is < MinFirstNameLength or > MaxFirstNameLength)
            throw new InvalidFirstNameException(value);
        
        Value = value.Trim();
    }
    
    public static implicit operator string(FirstName firstName) => firstName.Value;
    public static implicit operator FirstName(string firstName) => new(firstName);
}