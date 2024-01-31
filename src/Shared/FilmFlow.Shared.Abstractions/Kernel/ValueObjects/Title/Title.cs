namespace FilmFlow.Shared.Abstractions.Kernel.ValueObjects.Title;

public class Title : ValueObject
{
    private const int MaxLength = 100;
    private const int MinLength = 3;
    private string Value { get; }   
    
    public Title(string value)
    {
        if(string.IsNullOrWhiteSpace(value))
            throw new InvalidTitleException(value);
        
        if(value.Length is < MinLength or > MaxLength)
            throw new InvalidTitleException(value);
        
        Value = value.Trim();
    }
    
    public static implicit operator string(Title title) => title.Value;
    public static implicit operator Title(string title) => new(title);
    
}