using MediatR;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.CreateExercise;

public record CreateExerciseCommand(
    string Title,
    string Description,
    Guid AuthorId,
    DateTime CreationDate) : IRequest<Exercise>;
