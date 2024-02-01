using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Shared.Infrastructure.Exceptions;

internal interface IExceptionCompositionRoot
{
    ExceptionResponse Map(Exception exception);
}