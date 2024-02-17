namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.Read.Model;

internal class UserReadModel
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public string Email { get; init; }
    public Guid RoleId { get; init; }
    
    public RoleReadModel Role { get; init; }
    public bool IsActive { get; init; }
    
}