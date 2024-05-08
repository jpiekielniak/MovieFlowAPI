namespace MovieFlow.Modules.Movies.Application.Genres.Commands.DeleteGenre;

internal sealed class DeleteGenreValidator : AbstractValidator<DeleteGenreCommand>
{
    public DeleteGenreValidator()
    {
        RuleFor(x => x.GenreId)
            .NotNull()
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
}