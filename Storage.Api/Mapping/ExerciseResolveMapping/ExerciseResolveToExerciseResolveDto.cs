using AutoMapper;
using Storage.Api.DTOs.ExerciseResolveDtos;
using Storage.Domain.ExerciseData;

namespace Storage.Api.Mapping.ExerciseResolveMapping;

internal sealed class ExerciseResolveToExerciseResolveDto : Profile
{
    public ExerciseResolveToExerciseResolveDto()
    {
        CreateMap<ExerciseResolve, ExerciseResolveDto>()
            .ForMember(dto => dto.User, o => o.MapFrom(er => er.User))
            .ForMember(dto => dto.Exercise, o => o.MapFrom(er => er.Exercise))
            .ForMember(dto => dto.id, o => o.MapFrom(er => er.Id))
            .ForMember(dto => dto.Resolve, o => o.MapFrom(er => er.Resolve))
            .ForMember(dto => dto.SendingDate, o => o.MapFrom(er => er.SendingDate))
            .ForMember(dto => dto.ExecutionTime, o => o.MapFrom(er => er.ExecutionTime));
    }
}
