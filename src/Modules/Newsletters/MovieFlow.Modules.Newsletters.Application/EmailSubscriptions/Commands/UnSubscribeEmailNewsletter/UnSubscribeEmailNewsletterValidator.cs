namespace MovieFlow.Modules.Newsletters.Application.EmailSubscriptions.Commands.UnSubscribeEmailNewsletter;

internal class UnSubscribeEmailNewsletterValidator : AbstractValidator<UnSubscribeEmailNewsletterCommand>
{
    public UnSubscribeEmailNewsletterValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty()
            .NotNull()
            .EmailAddress();
    }
}