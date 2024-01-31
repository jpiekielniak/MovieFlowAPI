namespace FilmFlow.Shared.Abstractions.Time;

public interface IClock
{
    DateTime CurrentDateTime();
    DateTimeOffset CurrentDateTimeOffset();
}