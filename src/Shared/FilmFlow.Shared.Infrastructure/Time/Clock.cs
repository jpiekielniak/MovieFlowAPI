using FilmFlow.Shared.Abstractions.Time;

namespace FilmFlow.Shared.Infrastructure.Time;

public class Clock : IClock
{
    public DateTime CurrentDateTime() => DateTime.UtcNow;
    public DateTimeOffset CurrentDateTimeOffset() => DateTimeOffset.UtcNow;
}