
namespace MovieFlow.Modules.Movies.Core.Movies.Exceptions.Reviews;

internal sealed class ReviewDoesNotBelongToMovieException()
    : MovieFlowException("Review does not belong to movie");