using Storage.Application.DTOs;

namespace Storage.Application.ExerciseMediator.EditExercise;

public record EditExerciseCommand(Guid ExerciseId,
    string Title,
    string Description,
    List<TestCaseApplicationDto> TestCases) : IOperation;
