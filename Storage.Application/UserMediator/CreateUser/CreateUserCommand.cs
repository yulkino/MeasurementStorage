namespace Storage.Application.UserMediator.CreateUser;

public record CreateUserCommand(
    string Login,
    string Email,
    string Password) : IOperation;
