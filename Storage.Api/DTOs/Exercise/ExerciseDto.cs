using Storage.Api.DTOs.UserDtos;

namespace Storage.Api.DTOs.ExerciseDtos;

public sealed record ExerciseDto(
    Guid Id,
    string Title,
    string Description,
    string InputData,
    string OutputData,
    ShortUserDto Author,
    DateTime CreationDate,
    int ExerciseCount);
