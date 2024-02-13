using MovieFlow.Shared.Abstractions.Auth;

namespace MovieFlow.Modules.Users.Application.Users.Commands.SignIn;

internal record SignInResponse(JsonWebToken jwt);