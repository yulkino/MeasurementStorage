namespace Storage.Application.ExerciseMediator.GetExercise;

public record GetExerciseQuery(Guid ExerciseId) : IOperation;
