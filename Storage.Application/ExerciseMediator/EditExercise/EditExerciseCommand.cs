using MediatR;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.EditExercise;

public record EditExerciseCommand(Guid ExerciseId, 
    string Title,
    string Description) : IRequest<Exercise>;
