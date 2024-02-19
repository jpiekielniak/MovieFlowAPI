
namespace MovieFlow.Modules.Movies.Application.Movies.Commands.ChangeMovieInformation;

internal sealed class ChangeMovieInformationValidator : AbstractValidator<ChangeMovieInformationCommand>
{
    public ChangeMovieInformationValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.Description)
            .NotEmpty()
            .NotNull();
        
        RuleFor(x => x.ReleaseYear)
            .NotNull()
            .NotEmpty()
            .InclusiveBetween(1900, 2100);
    }
}