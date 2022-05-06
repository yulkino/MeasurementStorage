using AutoMapper;
using Storage.Api.DTOs.User;
using Storage.Domain.UserData;

namespace Storage.Api.Mapping.UserMapping;

internal sealed class UserDtoMapping : Profile
{
    public UserDtoMapping()
    {
        CreateMap<User, UserDto>()
            .ForMember(dto => dto.Login, o => o.MapFrom(u => u.Login))
            .ForMember(dto => dto.Id, o => o.MapFrom(u => u.Id))
            .ForMember(dto => dto.Email, o => o.MapFrom(u => u.Email));
    }
}
