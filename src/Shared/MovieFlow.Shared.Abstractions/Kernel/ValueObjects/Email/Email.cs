using System.Text.RegularExpressions;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Email.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Email;

public sealed class Email : ValueObject
{
    private static readonly Regex Regex = new(
        @"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" +
        @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$",
        RegexOptions.Compiled);
    
    private const int MaxEmailLength = 100;
    private const int MinEmailLength = 5;
        
    public string Value { get; }

    public Email(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidEmailException(value);

        if (value.Length is > MaxEmailLength or < MinEmailLength)
            throw new InvalidEmailException(value);

        value = value.ToLowerInvariant();
        if (!Regex.IsMatch(value))
            throw new InvalidEmailException(value);

        Value = value;
    }

    public static implicit operator string(Email email) => email.Value;

    public static implicit operator Email(string email) => new(email);
        
}