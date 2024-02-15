namespace MovieFlow.Shared.Abstractions.Exceptions.Errors;

public record ErrorsResponse(params Error[] Errors);
public record Error(string Code, string Message);
