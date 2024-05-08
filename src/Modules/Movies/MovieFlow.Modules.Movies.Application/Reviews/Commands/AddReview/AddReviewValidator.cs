namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.AddReview;

internal sealed class AddReviewValidator : AbstractValidator<AddReviewCommand>
{
    public AddReviewValidator()
    {
        RuleFor(x => x.Title)
            .NotNull()
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Content)
            .NotNull()
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(x => x.Rating)
            .NotNull()
            .NotEmpty()
            .InclusiveBetween(0, 10);
    }
}