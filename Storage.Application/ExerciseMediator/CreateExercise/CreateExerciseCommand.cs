using MediatR;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.CreateExercise;

public record CreateExerciseCommand(
    string Title,
    string Description,
    List<KeyValuePair<string, string>> TestCases,
    Guid AuthorId,
    DateTime CreationDate) : IOperation;
