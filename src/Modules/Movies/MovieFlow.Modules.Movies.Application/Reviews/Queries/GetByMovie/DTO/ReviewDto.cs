namespace MovieFlow.Modules.Movies.Application.Reviews.Queries.GetByMovie.DTO;

internal record ReviewDto(
    string Title,
    string Content,
    double Rating,
    int PositiveLikes,
    int NegativeLikes,
    Guid UserId);