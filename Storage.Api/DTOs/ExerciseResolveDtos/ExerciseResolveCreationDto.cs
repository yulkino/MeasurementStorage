using Storage.Api.DTOs.ExerciseDtos;
using Storage.Api.DTOs.UserDtos;

namespace Storage.Api.DTOs.ExerciseResolveDtos;

public sealed record ExerciseResolveCreationDto(
    ExerciseDto Exercise,
    ShortUserDto User,
    string Resolve,
    DateTime SendingDate);
