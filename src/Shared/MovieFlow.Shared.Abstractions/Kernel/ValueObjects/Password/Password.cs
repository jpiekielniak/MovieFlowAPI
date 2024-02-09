using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Password.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Password;

public class Password : ValueObject
{
    private const int MinLength = 6;
    private const int MaxLength = 100;
    public string Value { get; private set; }

    public Password(string value)
    {
        if(string.IsNullOrEmpty(value))
            throw new InvalidPasswordException(value);
        
        if(value.Length is < MinLength or > MaxLength)
            throw new InvalidPasswordException(value);
        
        Value = value.Trim();
    }
    
    public static implicit operator Password(string value) => new(value);
    public static implicit operator string(Password password) => password.Value;
}