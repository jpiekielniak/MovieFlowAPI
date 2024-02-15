namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Likes;

public class Likes
{
    public uint PositiveLikes { get; private set; } = 0;
    public uint NegativeLikes { get; private set; } = 0;
    
}