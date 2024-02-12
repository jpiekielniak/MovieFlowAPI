using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Name;

namespace MovieFlow.Modules.Users.Core.Users.Entities;

internal class Role
{
    public Guid Id { get; init; }
    public Name Name { get; set; }
    public IEnumerable<string> Permissions { get; internal set; }
    public IEnumerable<User> Users { get; private set; }
}