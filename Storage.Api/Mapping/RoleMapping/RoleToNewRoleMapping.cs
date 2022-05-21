using AutoMapper;
using Storage.Application.UserMediator.EditUserRole;

namespace Storage.Api.Mapping.RoleMapping;

internal sealed class RoleToNewRoleMapping : Profile
{
    public RoleToNewRoleMapping()
    {
        CreateMap<Roles, NewRole>()
            .ForMember(dto => dto == NewRole.Default,
                o => o.MapFrom(r => r == Roles.DEFAULT))
            .ForMember(dto => dto == NewRole.Editor,
                o => o.MapFrom(r => r == Roles.EDITOR))
            .ForMember(dto => dto == NewRole.Admin,
                o => o.MapFrom(r => r == Roles.ADMIN));
    }
}
