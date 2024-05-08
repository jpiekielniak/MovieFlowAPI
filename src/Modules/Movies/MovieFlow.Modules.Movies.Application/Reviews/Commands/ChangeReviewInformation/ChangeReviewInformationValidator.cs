namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.ChangeReviewInformation;

internal sealed class ChangeReviewInformationValidator : AbstractValidator<ChangeReviewInformationCommand>
{
    public ChangeReviewInformationValidator()
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
            .NotEmpty()
            .NotNull()
            .NotEqual(Guid.Empty);

        RuleFor(x => x.ReviewId)
            .NotEmpty()
            .NotNull()
            .NotEqual(Guid.Empty);
    }
}