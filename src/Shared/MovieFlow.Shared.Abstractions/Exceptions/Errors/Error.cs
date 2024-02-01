namespace MovieFlow.Shared.Abstractions.Exceptions.Errors;

public record ErrorsResponse(params Error[] Errors);
public record Error(string Code, string Message, string Property = null,  List<ErrorProperty> Properties = null);
public record ErrorProperty(string Key, object Value);
