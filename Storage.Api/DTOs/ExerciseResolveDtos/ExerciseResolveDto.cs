using Storage.Api.DTOs.ExerciseDtos;
using Storage.Api.DTOs.UserDtos;

namespace Storage.Api.DTOs.ExerciseResolveDtos;

public sealed record ExerciseResolveDto(
    Guid id,
    ExerciseDto Exercise,
    ShortUserDto User,
    string Resolve,
    DateTime SendingDate,
    double ExecutionTime);
