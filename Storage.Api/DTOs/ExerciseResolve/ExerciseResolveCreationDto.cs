using Storage.Api.DTOs.Exercise;
using Storage.Api.DTOs.User;

namespace Storage.Api.DTOs.ExerciseResolve;

public sealed record ExerciseResolveCreationDto(
    ExerciseDto Exercise,
    ShortUserDto User,
    string Resolve,
    DateTime SendingDate);
