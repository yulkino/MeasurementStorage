namespace Storage.Application.ExerciseMediator.GetExerciseLeaderBoard;

public record GetExerciseLeaderBoardQuery(Guid ExerciseId) : IOperation;
