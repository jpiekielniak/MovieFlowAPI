using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Users.Core.Users.Exceptions;

internal class PasswordsDoNotMatchException(string message) : MovieFlowException(message);