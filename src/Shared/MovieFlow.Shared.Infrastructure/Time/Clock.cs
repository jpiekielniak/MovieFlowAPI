using MovieFlow.Shared.Abstractions.Time;

namespace MovieFlow.Shared.Infrastructure.Time;

public class Clock : IClock
{
    public DateTime CurrentDateTime() => DateTime.UtcNow;
    public DateTimeOffset CurrentDateTimeOffset() => DateTimeOffset.UtcNow;
}