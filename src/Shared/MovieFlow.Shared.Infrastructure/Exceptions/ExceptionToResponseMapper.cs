using System.Collections.Concurrent;
using System.Net;
using MovieFlow.Shared.Abstractions.Exceptions;
using MovieFlow.Shared.Abstractions.Exceptions.Errors;
using FluentValidation;
using Humanizer;

namespace MovieFlow.Shared.Infrastructure.Exceptions;

internal class ExceptionToResponseMapper : IExceptionToResponseMapper
{
    private static readonly ConcurrentDictionary<Type, string> Codes = new();

    public ExceptionResponse Map(Exception exception) => exception switch
    {
        MovieFlowException ex => GetExceptionResponse(ex),
        ValidationException ex => GetExceptionResponse(ex),
        _ => GetExceptionResponse()
    };

    private static string GetErrorCode(object exception)
    {
        var type = exception.GetType();
        return Codes.GetOrAdd(type, type.Name.Underscore().Replace("_exception", string.Empty));
    }


    private static ExceptionResponse GetExceptionResponse(MovieFlowException ex)
    {
        var error = new Error(GetErrorCode(ex), ex.Message);

        var response = new ErrorsResponse(error);

        var exceptionResponse = new ExceptionResponse(response, HttpStatusCode.BadRequest);

        return exceptionResponse;
    }

    private static ExceptionResponse GetExceptionResponse(ValidationException ex)
    {
        var errors = ex.Errors
            .Select(q => new Error("validation_failed", q.ErrorMessage))
            .ToArray();

        var response = new ErrorsResponse(errors);

        return new ExceptionResponse(response, HttpStatusCode.BadRequest);
    }

    private static ExceptionResponse GetExceptionResponse()
    {
        var error = new Error("error", "There was an error.");

        var response = new ErrorsResponse(error);

        var exceptionResponse = new ExceptionResponse(response, HttpStatusCode.InternalServerError);

        return exceptionResponse;
    }
}