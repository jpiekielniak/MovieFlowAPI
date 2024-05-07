namespace MovieFlow.Modules.Movies.Application.Movies.Commands.AddPhotoToMovie;

internal class AddPhotoToMovieValidator : AbstractValidator<AddPhotoToMovieCommand>
{
    public AddPhotoToMovieValidator()
    {
        RuleFor(x => x.Photo)
            .NotNull()
            .Must(x => x.Length > 0);

        RuleFor(x => x.MovieId)
            .NotNull()
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}