using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Country.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Country;

public class Country : ValueObject
{
    private const int MinCountryLength = 3;
    private const int MaxCountryLength = 100;

    public string Value { get; }

    public Country(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            throw new InvalidCountryException(value);

        if (value.Length is < MinCountryLength or > MaxCountryLength)
            throw new InvalidCountryException(value);

        Value = value.Trim();
    }

    public static implicit operator string(Country country) => country.Value;
    public static implicit operator Country(string country) => new(country);
}