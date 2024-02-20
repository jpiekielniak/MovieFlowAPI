using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Recipient.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Recipient;

public class Recipient : ValueObject
{
    public string Value { get; }

    public Recipient(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidRecipientException(value);

        if (!value.Contains('@'))
            throw new InvalidRecipientException(value);

        Value = value;
    }

    public static implicit operator Recipient(string value) => new(value);
    public static implicit operator string(Recipient recipient) => recipient.Value;
}