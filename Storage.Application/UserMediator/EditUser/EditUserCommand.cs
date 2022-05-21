namespace Storage.Application.UserMediator.EditUser;

public record EditUserCommand(Guid UserId,
    string? Login,
    string? Password,
    string? AvatarUrl) : IOperation;
