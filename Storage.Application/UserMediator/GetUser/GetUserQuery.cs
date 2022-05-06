using MediatR;
using Storage.Domain.UserData;

namespace Storage.Application.UserMediator.GetUser;

public record GetUserQuery(Guid UserId) : IRequest<User>;
