namespace Storage.Api.DTOs.ExerciseDtos;

public sealed record ExerciseEditionDto(
    string Title,
    string Description,
    string InputData,
    string OutputData);
