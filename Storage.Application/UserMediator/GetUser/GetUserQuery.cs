namespace Storage.Application.UserMediator.GetUser;

public record GetUserQuery(Guid UserId) : IOperation;
