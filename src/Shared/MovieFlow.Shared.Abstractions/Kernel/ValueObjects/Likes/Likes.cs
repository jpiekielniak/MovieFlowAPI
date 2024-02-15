namespace MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Likes;

public class Likes
{
    public uint PositiveLikes { get; private set; }
    public uint NegativeLikes { get; private set; }

    public Likes(uint positiveLikes, uint negativeLikes)
    {
        PositiveLikes = positiveLikes;
        NegativeLikes = negativeLikes;
    }
}