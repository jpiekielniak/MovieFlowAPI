namespace MovieFlow.Modules.Users.Application.Users.Commands.ChangePassword;

internal record ChangePasswordCommand(string CurrentPassword, string NewPassword,
    string ConfirmNewPassword): IRequest;