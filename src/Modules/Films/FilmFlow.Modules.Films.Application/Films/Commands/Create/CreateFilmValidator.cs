using FluentValidation;

namespace FilmFlow.Modules.Films.Application.Films.Commands.Create;

internal sealed class CreateFilmValidator : AbstractValidator<CreateFilmCommand>
{
    public CreateFilmValidator()
    {
        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty();

        RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.ReleaseYear)
            .NotNull()
            .NotEmpty()
            .GreaterThanOrEqualTo(1900)
            .LessThanOrEqualTo(DateTime.Now.Year);

        RuleFor(x => x.Rating)
            .NotNull()
            .NotEmpty()
            .GreaterThanOrEqualTo(0.0)
            .LessThanOrEqualTo(10.0);
        
    }
}