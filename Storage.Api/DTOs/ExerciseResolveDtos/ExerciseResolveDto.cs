using Storage.Api.DTOs.Exercise;
using Storage.Api.DTOs.UserDtos;

namespace Storage.Api.DTOs.ExerciseResolveDtos;

public sealed record ExerciseResolveDto(
    Guid id,
    ShortExerciseDto Exercise,
    ShortUserDto User,
    string Resolve,
    DateTime SendingDate,
    double ExecutionTime);
