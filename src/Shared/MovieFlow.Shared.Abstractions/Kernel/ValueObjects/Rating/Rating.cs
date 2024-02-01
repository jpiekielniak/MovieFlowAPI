using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Rating.Exceptions;

namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Rating;

public class Rating : ValueObject
{
    private const double MaxRating = 10.0;
    private const double MinRating = 0.0;
    public double Value { get; }

    public Rating(double value)
    {
        if(value is < MinRating or > MaxRating)
            throw new InvalidRatingException(value);
        
        Value = value;
    }
    
    public static implicit operator double(Rating rating) => rating.Value;
    public static implicit operator Rating(double rating) => new(rating);
}