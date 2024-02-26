namespace MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsGroupedByRating;

internal record GetReviewsGroupedByRatingQuery(Guid MovieId) : IRequest<GetReviewsGroupedByRatingResponse>;