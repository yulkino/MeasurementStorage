using MediatR;

namespace Storage.Application.ExerciseMediator.DeleteExercise;

public record DeleteExerciseCommand(Guid ExerciseId) : IRequest<Unit>;
