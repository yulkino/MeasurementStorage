using Storage.Api.DTOs.Exercise;

namespace Storage.Api.DTOs.ExerciseDtos;

public sealed record ExerciseEditionDto(
    string Title,
    string Description,
    List<TestCaseDto> TestCases);
