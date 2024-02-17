namespace MovieFlow.Modules.Users.Infrastructure.EF.Users.Configurations.Read.Model;

internal class RoleReadModel
{
    public Guid Id { get; init; }
    public string Name { get; init; }
    public IReadOnlyCollection<UserReadModel> Users { get; init; }
}