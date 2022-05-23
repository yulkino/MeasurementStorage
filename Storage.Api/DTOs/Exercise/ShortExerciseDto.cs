namespace Storage.Api.DTOs.Exercise;

public sealed record ShortExerciseDto(
    Guid Id,
    string Title,
    int ExerciseResolveCount);
