namespace MovieFlow.Modules.Users.Application.Users.Commands.ChangePassword;

internal sealed class ChangePasswordValidator : AbstractValidator<ChangePasswordCommand>
{
    public ChangePasswordValidator()
    {
        RuleFor(x => x.CurrentPassword)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.NewPassword)
            .NotEmpty()
            .NotNull();

        RuleFor(x => x.ConfirmNewPassword)
            .NotEmpty()
            .NotNull();
    }
}