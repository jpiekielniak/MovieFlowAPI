using MovieFlow.Shared.Abstractions.Exceptions;

namespace MovieFlow.Modules.Users.Core.Users.Exceptions.Roles;

internal class RoleNotFoundException(string role) : MovieFlowException($"Role {role} not found.");