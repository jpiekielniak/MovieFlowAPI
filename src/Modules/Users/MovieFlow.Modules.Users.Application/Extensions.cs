using MovieFlow.Modules.Users.Application.Users.Commands.ChangePassword;
using MovieFlow.Modules.Users.Application.Users.Commands.SignIn;
using MovieFlow.Modules.Users.Application.Users.Commands.SignUp;

[assembly: InternalsVisibleTo("MovieFlow.Modules.Users.Api")]
[assembly: InternalsVisibleTo("MovieFlow.Modules.Users.Infrastructure")]

namespace MovieFlow.Modules.Users.Application;

internal static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddMediatR(cfg=>cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));

        services
            .AddScoped<IValidator<ChangePasswordCommand>, ChangePasswordValidator>()
            .AddScoped<IValidator<SignInCommand>, SignInValidator>()
            .AddScoped<IValidator<SignUpCommand>, SignUpValidator>();
        
        return services;
    }
}