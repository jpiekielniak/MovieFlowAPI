namespace MovieFlow.Modules.Movies.Application.Movies.Commands.DeleteActorFromMovie;

internal sealed class DeleteActorFromMovieValidator : AbstractValidator<DeleteActorFromMovieCommand>
{
    public DeleteActorFromMovieValidator()
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