namespace Storage.Application.UserMediator.LoginUser;

public record LoginUserQuery(string Login, string Password) : IOperation;
