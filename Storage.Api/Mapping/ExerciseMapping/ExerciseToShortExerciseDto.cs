using AutoMapper;
using Storage.Api.DTOs.Exercise;
using Storage.Domain.ExerciseData;

namespace Storage.Api.Mapping.ExerciseMapping;

internal sealed class ExerciseToShortExerciseDto : Profile
{
    public ExerciseToShortExerciseDto()
    {
        CreateMap<(Exercise Ex, int Count), ShortExerciseDto>()
            .ForMember(dto => dto.Id, o => o.MapFrom(e => e.Ex.Id))
            .ForMember(dto => dto.Title, o => o.MapFrom(e => e.Ex.Title))
            .ForMember(dto => dto.ExerciseResolveCount, o => o.MapFrom(e => e.Count));
    }
}
