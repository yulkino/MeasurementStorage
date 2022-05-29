using AutoMapper;
using Storage.Api.DTOs.ExerciseResolveDtos;
using Storage.Domain.ExerciseData;

namespace Storage.Api.Mapping.ExerciseResolveMapping;

internal sealed class VCToVersionControleExerciseResolvesDto : Profile
{
    public VCToVersionControleExerciseResolvesDto()
    {
        CreateMap<(ExerciseResolve ER, List<ExerciseResolve> ERs), VersionControlExerciseResolvesDto>()
            .ForMember(vc => vc.ExerciseResolve, o => o.MapFrom(vc => vc.ER))
            .ForMember(vc => vc.ShortExerciseResolve, o => o.MapFrom(vc => vc.ERs));
    }
}