using Storage.Api.DTOs.Exercise;

namespace Storage.Api.DTOs.ExerciseDtos;

public sealed record ExerciseCreationDto(
    string Title,
    string Description,
    List<TestCaseDto> TestCases,
    Guid AuthorId,
    DateTime CreationDate);
