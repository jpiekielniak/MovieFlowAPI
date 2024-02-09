using MovieFlow.Shared.Abstractions.Kernel;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Name;

namespace MovieFlow.Modules.Users.Core.Entities;

internal class Role : Entity
{
    public Name Name { get; private set; }
    public IEnumerable<string> Permissions { get; private set; }
    public IEnumerable<User> Users { get; private set; }
}