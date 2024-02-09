using MovieFlow.Shared.Abstractions.Kernel;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Email;
using MovieFlow.Shared.Abstractions.Kernel.ValueObjects.Password;

namespace MovieFlow.Modules.Users.Core.Entities;

internal sealed class User : Entity
{
    public Email Email { get; private set; }
    private bool EmailConfirmed { get; set; } = false;
    private DateTimeOffset? EmailConfirmedAt { get; set; }
    public Password Password { get; private set; }
    private DateTimeOffset? LastChangePasswordAt { get; set; }
    public bool IsActive { get; private set; } = true;
    public Guid RoleId { get; private set; }
    public Role Role { get; private set; }

    private User() //for EF
    {
    }

    private User(Email email, Password password, Role role, EntityState state)
    {
        Id = Guid.NewGuid();
        Email = email;
        Password = password;
        Role = role;
        State = state;
    }

    public static User Create(Email email, Password password, Role role)
        => new(email, password, role, EntityState.Added);
}