namespace MovieFlow.Modules.Movies.Application.Reviews.Commands.Add;

internal sealed class AddReviewValidator : AbstractValidator<AddReviewCommand>
{
    public AddReviewValidator()
    {
        RuleFor(x => x.Title)
            .NotEmpty()
            .MaximumLength(100);

        RuleFor(x => x.Content)
            .NotEmpty()
            .MaximumLength(1000);

        RuleFor(x => x.Rating)
            .InclusiveBetween(0, 10);
    }
}