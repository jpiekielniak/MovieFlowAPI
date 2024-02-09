using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Shared.Infrastructure.Auth.Exceptions;

public class MissingIssuerSigningKeyException(string message)
    : MovieFlowException($"Missing issuer signing key: {message}");