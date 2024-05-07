namespace MovieFlow.Modules.Movies.Application.Movies.Commands.DeleteMovie;

internal class DeleteMovieValidator : AbstractValidator<DeleteMovieCommand>
{
    public DeleteMovieValidator()
    {
        RuleFor(x => x.MovieId)
            .NotNull()
            .NotEmpty()
            .NotEqual(Guid.Empty);
    }
    
}