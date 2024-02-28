namespace MovieFlow.Modules.Movies.Application.Directors.Commands.CreateDirector;

internal sealed class CreateDirectorValidator : AbstractValidator<CreateDirectorCommand>
{
    public CreateDirectorValidator()
    {
        RuleFor(x => x.FirstName)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(50)
            .Must(fn => !string.IsNullOrWhiteSpace(fn) && char.IsUpper(fn[0]));

        RuleFor(x => x.LastName)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(50)
            .Must(ln => !string.IsNullOrWhiteSpace(ln) && char.IsUpper(ln[0]));

        RuleFor(x => x.DateOfBirth)
            .NotNull()
            .NotEmpty()
            .LessThan(DateTime.UtcNow);

        RuleFor(x => x.Country)
            .NotEmpty()
            .NotNull()
            .MinimumLength(3)
            .MaximumLength(50)
            .Must(c => !string.IsNullOrWhiteSpace(c) && char.IsUpper(c[0]));
    }
}