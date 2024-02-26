using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Users.Core.Users.Exceptions.Users;

internal class UserIsAlreadyActiveException(Guid userId) 
    : MovieFlowException($"User with id: {userId} is already active.");