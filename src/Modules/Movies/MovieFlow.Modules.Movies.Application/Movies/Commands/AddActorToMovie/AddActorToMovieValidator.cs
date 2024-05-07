namespace MovieFlow.Modules.Movies.Application.Movies.Commands.AddActorToMovie;

internal sealed class AddActorToMovieValidator : AbstractValidator<AddActorToMovieCommand>
{
    public AddActorToMovieValidator()
    {
        RuleFor(x => x.ActorId)
            .NotNull()
            .NotEmpty()
            .NotEqual(Guid.Empty);

        RuleFor(x => x.MovieId)
            .NotNull()
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
    
}