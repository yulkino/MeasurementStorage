namespace Storage.Application.ExerciseMediator.GetExerciseStatistics;

public record GetExerciseStatisticsQuery(Guid ExerciseId) : IOperation;
