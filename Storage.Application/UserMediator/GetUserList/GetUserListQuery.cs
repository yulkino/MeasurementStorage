using MediatR;
using Storage.Domain.UserData;

namespace Storage.Application.UserMediator.GetUserList;

public record GetUserListQuery : IRequest<List<User>>;
