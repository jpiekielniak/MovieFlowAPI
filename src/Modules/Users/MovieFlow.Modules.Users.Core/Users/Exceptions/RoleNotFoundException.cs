using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Users.Core.Users.Exceptions;

internal class RoleNotFoundException(string message) : MovieFlowException($"Role {message} not found.");