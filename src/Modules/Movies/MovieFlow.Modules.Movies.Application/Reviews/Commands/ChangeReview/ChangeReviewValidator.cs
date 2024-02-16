namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.ChangeReview;

internal sealed class ChangeReviewValidator : AbstractValidator<ChangeReviewCommand>
{
    public ChangeReviewValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2);

        RuleFor(x => x.Content)
            .NotEmpty()
            .NotNull()
            .MinimumLength(2);

        RuleFor(x => x.Rating)
            .NotEmpty()
            .NotNull()
            .InclusiveBetween(1, 10);

        RuleFor(x => x.MovieId)
            .NotEqual(Guid.Empty);

        RuleFor(x => x.ReviewId)
            .NotEqual(Guid.Empty);
    }
}