namespace Storage.Api.DTOs.Exercise;

public sealed record ExerciseEditionDto(
    string Title,
    string Description,
    string InputData,
    string OutputData);
