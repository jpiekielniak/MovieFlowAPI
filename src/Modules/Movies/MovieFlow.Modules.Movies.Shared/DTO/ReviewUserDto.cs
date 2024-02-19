namespace MovieFlow.Modules.Movies.Shared.DTO;

public record ReviewUserDto(
    Guid ReviewId,
    string Title,
    string Content,
    double Rating,
    int PositiveLikes,
    int NegativeLikes,
    Guid MovieId);