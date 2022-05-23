using Storage.Api.DTOs.Exercise;
using Storage.Api.DTOs.UserDtos;

namespace Storage.Api.DTOs.ExerciseDtos;

public sealed record ExerciseDto(
    Guid Id,
    string Title,
    string Description,
    List<TestCaseDto> TestCases,
    ShortUserDto Author,
    DateTime CreationDate);
