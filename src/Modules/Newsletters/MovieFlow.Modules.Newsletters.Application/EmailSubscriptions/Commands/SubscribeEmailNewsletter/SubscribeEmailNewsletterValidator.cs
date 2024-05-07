namespace MovieFlow.Modules.Newsletters.Application.EmailSubscriptions.Commands.SubscribeEmailNewsletter;

internal sealed class SubscribeEmailNewsletterValidator : AbstractValidator<SubscribeEmailNewsletterCommand>
{
    public SubscribeEmailNewsletterValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();
    }
}