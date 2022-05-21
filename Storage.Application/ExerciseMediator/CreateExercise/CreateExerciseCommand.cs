using Storage.Application.DTOs;

namespace Storage.Application.ExerciseMediator.CreateExercise;

public record CreateExerciseCommand(
    string Title,
    string Description,
    List<TestCaseApplicationDto> TestCases,
    Guid AuthorId,
    DateTime CreationDate) : IOperation;
