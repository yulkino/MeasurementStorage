using Storage.Api.DTOs.ExerciseDtos;
using Storage.Api.DTOs.UserDtos;

namespace Storage.Api.DTOs.ExerciseResolveDtos;

public sealed record ExerciseResolveCreationDto(
    Guid ExerciseId,
    Guid UserId,
    string Resolve,
    DateTime SendingDate);
