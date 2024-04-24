namespace MovieFlow.Modules.Movies.Infrastructure.EF.Movies.Configurations.Read.Model;

internal sealed class ActorReadModel
{
    public Guid Id { get; init; }
    public string FirstName { get; init; }
    public string LastName { get; init; }
    public DateTime DateOfBirth { get; init; }
    public string Country { get; init; }
    public int Age => DateTime.Now.Year - DateOfBirth.Year;
    public IReadOnlyCollection<PhotoReadModel> Photos { get; init; }
    public IReadOnlyCollection<MovieReadModel> Movies { get; init; }
}