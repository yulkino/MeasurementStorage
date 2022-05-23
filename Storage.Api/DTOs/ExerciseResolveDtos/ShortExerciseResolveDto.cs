namespace Storage.Api.DTOs.ExerciseResolveDtos;

public sealed record ShortExerciseResolveDto(
    Guid id,
    DateTime SendingDate,
    double ExecutionTime);

