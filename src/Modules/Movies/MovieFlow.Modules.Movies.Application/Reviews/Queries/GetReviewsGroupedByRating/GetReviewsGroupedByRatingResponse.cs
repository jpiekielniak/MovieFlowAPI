using MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsGroupedByRating.DTO;

namespace MovieFlow.Modules.Movies.Application.Reviews.Queries.GetReviewsGroupedByRating;

internal record GetReviewsGroupedByRatingResponse(List<GroupedReviewsDto> GroupedReviews);