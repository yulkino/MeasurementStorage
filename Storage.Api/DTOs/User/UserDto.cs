namespace Storage.Api.DTOs.User;

public sealed record UserDto(Guid Id, string Login, string Email, int ExerciseCount); //ROLES?
