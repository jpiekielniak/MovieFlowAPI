using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.Delete;

internal sealed class ReviewDoesNotBelongToMovieException()
    : MovieFlowException("Review does not belong to movie");