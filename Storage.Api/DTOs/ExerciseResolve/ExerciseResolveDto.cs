using Storage.Api.DTOs.Exercise;
using Storage.Api.DTOs.User;

namespace Storage.Api.DTOs.ExerciseResolve;

public sealed record ExerciseResolveDto(
    Guid id,
    ExerciseDto Exercise,
    ShortUserDto User,
    string Resolve,
    DateTime SendingDate,
    double ExecutionTime);
