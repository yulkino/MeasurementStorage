using MediatR;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.GetExerciseStatistics;

public record GetExerciseStatisticsQuery(Guid ExerciseId) : IOperation;
