using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Users.Core.Users.Exceptions.Users;

internal class UserAlreadyExistsException(string message) : MovieFlowException(message);