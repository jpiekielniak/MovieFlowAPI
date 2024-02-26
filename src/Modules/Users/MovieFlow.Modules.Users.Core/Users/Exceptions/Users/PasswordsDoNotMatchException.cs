using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Users.Core.Users.Exceptions.Users;

internal class PasswordsDoNotMatchException(string message) : MovieFlowException(message);