using AutoMapper;
using Storage.Api.DTOs.Exercise;
using Storage.Application.DTOs;

namespace Storage.Api.Mapping.ExerciseMapping;

internal sealed class TestCaseDtoToTestCaseApplicationDto : Profile
{
    public TestCaseDtoToTestCaseApplicationDto()
    {
        CreateMap<TestCaseDto, TestCaseApplicationDto>()
            .ForMember(dto => dto.Output, o => o.MapFrom(adto => adto.Output))
            .ForMember(dto => dto.Input, o => o.MapFrom(adto => adto.Input));
    }
}
