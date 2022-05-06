using MediatR;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.GetExercise;

public record GetExerciseQuery(Guid ExerciseId) : IRequest<Exercise>;
