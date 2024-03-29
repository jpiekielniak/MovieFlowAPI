using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Users.Core.Users.Exceptions.Users;

internal class UserNotFoundException(Guid userId) 
    : MovieFlowException($"User with id {userId} was not found.");