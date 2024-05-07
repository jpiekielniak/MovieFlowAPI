namespace MovieFlow.Modules.Movies.Application.Actors.Commands.DeleteActor;

internal sealed class DeleteActorValidator : AbstractValidator<DeleteActorCommand>
{
    public DeleteActorValidator()
    {
        RuleFor(x => x.ActorId)
            .NotNull()
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}