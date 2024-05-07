namespace MovieFlow.Modules.Movies.Application.Movies.Commands.DeletePhotoFromMovie;

internal sealed class DeletePhotoFromMovieValidator : AbstractValidator<DeletePhotoFromMovieCommand>
{
    public DeletePhotoFromMovieValidator()
    {
        RuleFor(x => x.PhotoId)
            .NotNull()
            .NotEmpty()
            .NotEqual(Guid.Empty);

        RuleFor(x => x.MovieId)
            .NotNull()
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
    
}