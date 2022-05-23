using AutoMapper;
using Storage.Api.DTOs.ExerciseDtos;
using Storage.Domain.ExerciseData;

namespace Storage.Api.Mapping.ExerciseMapping;

internal sealed class ExerciseToExerciseDto : Profile
{
    public ExerciseToExerciseDto()
    {
        CreateMap<Exercise, ExerciseDto>()
            .ForMember(dto => dto.Author, o => o.MapFrom(e => e.Author))
            .ForMember(dto => dto.TestCases, o => o.MapFrom(e => e.TestCases))
            .ForMember(dto => dto.CreationDate, o => o.MapFrom(e => e.CreationDate))
            .ForMember(dto => dto.Description, o => o.MapFrom(e => e.Description))
            .ForMember(dto => dto.Title, o => o.MapFrom(e => e.Title))
            .ForMember(dto => dto.Id, o => o.MapFrom(e => e.Id));
    }
}
