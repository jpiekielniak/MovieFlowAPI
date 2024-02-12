using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Users.Core.Exceptions;

internal class RoleNotFoundException(string message) : MovieFlowException($"Role {message} not found.");