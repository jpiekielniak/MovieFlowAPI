using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Users.Core.Users.Exceptions;

internal class UserNotActiveException(Guid id) : MovieFlowException($"User with id: '{id}' is not active.");