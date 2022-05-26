using AutoMapper;
using Storage.Application.UserMediator.EditUserRole;

namespace Storage.Api.Mapping.RoleMapping;

internal sealed class RoleToNewRoleMapping : Profile
{
    public RoleToNewRoleMapping()
    {
        CreateMap<Roles, NewRole>()
            .ConvertUsing(r => (NewRole) r);
    }
}
