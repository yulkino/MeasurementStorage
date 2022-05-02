using Storage.Api.DTOs.User;

namespace Storage.Api.DTOs.Exercise;

public sealed record ExerciseDto(
    Guid Id,
    string Title,
    string Description,
    string InputData,
    string OutputData,
    ShortUserDto Author,
    DateTime CreationDate);
