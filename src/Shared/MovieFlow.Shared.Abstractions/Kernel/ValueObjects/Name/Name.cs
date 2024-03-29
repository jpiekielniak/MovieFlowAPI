using System.Text.RegularExpressions;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Name.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Name;

public partial class Name : ValueObject
{
    private const int MaxGenreLength = 50;
    private const int MinGenreLength = 3;
    private static readonly Regex NameRegex = Regex();


    public string Value { get; }

    public Name(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidNameException(value);

        if (value.Length is < MinGenreLength or > MaxGenreLength)
            throw new InvalidNameException(value);

        if (!NameRegex.IsMatch(value))
            throw new InvalidNameException(value);

        Value = value.Trim();
    }

    public static implicit operator string(Name name) => name.Value;
    public static implicit operator Name(string name) => new(name);

    [GeneratedRegex("^[A-Z][a-zA-Z0-9 ]+$")]
    private static partial Regex Regex();
}