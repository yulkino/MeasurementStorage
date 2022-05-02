using MediatR;
using Storage.Domain.UserData;
namespace Storage.Application.RoleMediator.GetRoleList;

public record GetRoleListQuery : IRequest<List<Role>>;
