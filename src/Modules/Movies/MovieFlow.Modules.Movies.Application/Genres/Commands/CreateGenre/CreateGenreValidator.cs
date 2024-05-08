namespace MovieFlow.Modules.Movies.Application.Genres.Commands.CreateGenre;

internal sealed class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
{
    public CreateGenreValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(50)
            .Must(name => char.IsUpper(name[0]))
            .WithMessage("Name must start with an uppercase letter");
    }
}