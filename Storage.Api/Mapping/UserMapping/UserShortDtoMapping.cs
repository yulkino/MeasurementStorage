using AutoMapper;
using Storage.Api.DTOs.UserDtos;
using Storage.Domain.UserData;

namespace Storage.Api.Mapping.UserMapping;

internal sealed class UserShortDtoMapping : Profile
{
    public UserShortDtoMapping()
    {
        CreateMap<User, ShortUserDto>()
            .ForMember(dto => dto.Id, o => o.MapFrom(u => u.Id))
            .ForMember(dto => dto.Login, o => o.MapFrom(u => u.Login));
    }
}
