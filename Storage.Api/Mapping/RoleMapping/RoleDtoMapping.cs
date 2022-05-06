using AutoMapper;
using Storage.Api.DTOs.RoleDtos;
using Storage.Domain.UserData;


namespace Storage.Api.Mapping.RoleMapping;

internal sealed class RoleDtoMapping : Profile
{
    public RoleDtoMapping()
    {
        CreateMap<Role, RoleDto>()
            .ForMember(dto => dto.Name, o => o.MapFrom(r => r.Name));
    }
}
