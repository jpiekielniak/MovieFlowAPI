namespace FilmFlow.Shared.Abstractions.Kernel.ValueObjects.ReleaseYear;

public class ReleaseYear : ValueObject
{
    private const int MinReleaseYear = 1900;
    private int MaxReleaseYear = DateTime.Now.Year;

    public int Value { get; }

    public ReleaseYear(int value)
    {
        if (value < MinReleaseYear || value > MaxReleaseYear)
            throw new InvalidReleaseYearException(value);

        Value = value;
    }
    
    public static implicit operator int(ReleaseYear releaseYear) => releaseYear.Value;
    public static implicit operator ReleaseYear(int releaseYear) => new(releaseYear);
}