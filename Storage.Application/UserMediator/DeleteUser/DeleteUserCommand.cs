namespace Storage.Application.UserMediator.DeleteUser;

public record DeleteUserCommand(Guid UserId) : IOperation;
