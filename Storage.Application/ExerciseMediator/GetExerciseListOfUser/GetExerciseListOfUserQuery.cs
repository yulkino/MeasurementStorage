namespace Storage.Application.ExerciseMediator.GetExerciseListOfUser;

public record GetExerciseListOfUserQuery(Guid UserId) : IOperation;
