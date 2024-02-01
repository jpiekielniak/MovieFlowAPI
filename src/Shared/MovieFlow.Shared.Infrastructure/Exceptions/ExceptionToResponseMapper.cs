using System.Collections.Concurrent;
using System.Net;
using System.Reflection;
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
        var exceptionType = ex.GetType();
        var propertiesToMap = exceptionType.GetProperties(BindingFlags.Public | BindingFlags.Instance | BindingFlags.DeclaredOnly);
        var properties = new List<ErrorProperty>();
        foreach (var property in propertiesToMap)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(ex)?.ToString(); 

            if (!string.IsNullOrEmpty(propertyValue))
            {
                properties.Add(new ErrorProperty(propertyName, propertyValue)); 
            }
        }
        
        var error = new Error(GetErrorCode(ex), ex.Message, Properties: properties);
        
        var response = new ErrorsResponse(error);

        var exceptionResponse = new ExceptionResponse(response, HttpStatusCode.BadRequest);

        return exceptionResponse;
    }

    private static ExceptionResponse GetExceptionResponse(ValidationException ex)
    {
        var errors = ex.Errors
            .Select(q => new Error(q.ErrorCode, q.ErrorMessage, q.PropertyName, MapFormattedValues(q.FormattedMessagePlaceholderValues)))
            .ToArray();

        var response = new ErrorsResponse(errors);

        return new ExceptionResponse(response, HttpStatusCode.BadRequest);
    }

    private static List<ErrorProperty> MapFormattedValues(Dictionary<string, object> formattedValues)
    {
        return formattedValues?.Select(kv => new ErrorProperty(kv.Key, kv.Value)).ToList();
    }
    

    private static ExceptionResponse GetExceptionResponse()
    {
        var error = new Error("error", "There was an error.");

        var response = new ErrorsResponse(error);

        var exceptionResponse = new ExceptionResponse(response, HttpStatusCode.InternalServerError);

        return exceptionResponse;
    }
}