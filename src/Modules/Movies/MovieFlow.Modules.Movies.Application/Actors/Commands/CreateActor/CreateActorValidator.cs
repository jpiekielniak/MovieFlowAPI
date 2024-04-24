using MovieFlow.Modules.Movies.Core.Movies.Entities;

namespace MovieFlow.Modules.Movies.Application.Actors.Commands.CreateActor;

internal sealed class CreateActorValidator : AbstractValidator<Actor>
{
    public CreateActorValidator()
    {
        RuleFor(x => x.FirstName)
            .NotNull()
            .NotEmpty()
            .WithMessage("First name is required.");

        RuleFor(x => x.LastName)
            .NotNull()
            .NotEmpty()
            .WithMessage("Last name is required.");

        RuleFor(x => x.DateOfBirth)
            .NotNull()
            .NotEmpty()
            .WithMessage("Date of birth is required.");

        RuleFor(x => x.Country)
            .NotNull()
            .NotEmpty()
            .WithMessage("Country is required.");
    }
}