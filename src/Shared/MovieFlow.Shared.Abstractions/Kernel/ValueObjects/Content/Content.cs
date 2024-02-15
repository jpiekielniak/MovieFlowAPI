using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Content.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Content;

public class Content : ValueObject
{
    private const int MinContentLength = 2;
    private const int MaxContentLength = 3000;

    public string Value { get; private set; }

    public Content(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidContentException(value);

        if (value.Length is < MinContentLength or > MaxContentLength)
            throw new InvalidContentException(value);

        Value = value;
    }

    public static implicit operator Content(string value) => new(value);
    public static implicit operator string(Content value) => value.Value;
}