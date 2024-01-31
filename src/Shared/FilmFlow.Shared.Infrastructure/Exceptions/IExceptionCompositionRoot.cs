using FilmFlow.Shared.Abstractions.Exceptions;

namespace FilmFlow.Shared.Infrastructure.Exceptions;

internal interface IExceptionCompositionRoot
{
    ExceptionResponse Map(Exception exception);
}