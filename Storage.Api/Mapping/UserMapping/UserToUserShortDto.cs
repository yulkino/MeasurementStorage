using AutoMapper;
using Storage.Api.DTOs.UserDtos;
using Storage.Domain.UserData;

namespace Storage.Api.Mapping.UserMapping;

internal sealed class UserToUserShortDto : Profile
{
    public UserToUserShortDto()
    {
        CreateMap<User, ShortUserDto>()
            .ForMember(dto => dto.Id, o => o.MapFrom(u => u.Id))
            .ForMember(dto => dto.Login, o => o.MapFrom(u => u.Login))
            .ForMember(dto => dto.AvatarUrl, o => o.MapFrom(u => u.AvatarUrl));
    }
}
