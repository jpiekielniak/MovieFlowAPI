namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.Read.Model;

internal class UserReadModel
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public bool EmailConfirmed { get; init; }
    public DateTimeOffset? EmailConfirmedAt { get; init; }
    public DateTimeOffset? LastChangePasswordAt { get; init; }
    public Guid RoleId { get; init; }

    public RoleReadModel Role { get; init; }
    public bool IsActive { get; init; }
}