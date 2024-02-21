using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Users.Core.Users.Exceptions;

internal class UserNotActiveException(Guid userId) 
    : MovieFlowException($"User with id: '{userId}' is not active.");