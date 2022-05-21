using AutoMapper;
using Storage.Api.DTOs.UserDtos;
using Storage.Domain.UserData;

namespace Storage.Api.Mapping.UserMapping;

internal sealed class UserToUserDto : Profile
{
    public UserToUserDto()
    {
        CreateMap<User, UserDto>()
            .ForMember(dto => dto.Login, o => o.MapFrom(u => u.Login))
            .ForMember(dto => dto.Id, o => o.MapFrom(u => u.Id))
            .ForMember(dto => dto.Email, o => o.MapFrom(u => u.Email))
            .ForMember(dto => dto.AvatarUrl, o => o.MapFrom(u => u.AvatarUrl));
    }
}
