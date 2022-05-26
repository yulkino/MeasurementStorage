using AutoMapper;
using Storage.Api.DTOs.Exercise;
using Storage.Domain.ExerciseData;

namespace Storage.Api.Mapping.ExerciseMapping;

internal sealed class TestCaseToTestCaseDto : Profile
{
    public TestCaseToTestCaseDto()
    {
        CreateMap<TestCase, TestCaseDto>()
            .ForMember(dto => dto.Output, o => o.MapFrom(tc => tc.Output))
            .ForMember(dto => dto.Input, o => o.MapFrom(tc => tc.Input));
    }
}