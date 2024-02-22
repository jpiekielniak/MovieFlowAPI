using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Users.Application.Users.Commands.ChangePassword;

internal class PasswordsDoNotMatchException(string message) : MovieFlowException(message);