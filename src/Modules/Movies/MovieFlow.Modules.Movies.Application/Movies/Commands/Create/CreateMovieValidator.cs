using FluentValidation;

namespace MovieFlow.Modules.Movies.Application.Movies.Commands.Create;

internal sealed class CreateMovieValidator : AbstractValidator<CreateMovieCommand>
{
    public CreateMovieValidator()
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