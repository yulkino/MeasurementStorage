using MediatR;
using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.EditExercise;

internal sealed class EditExerciseCommandHandler : IOperationHandler<EditExerciseCommand>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly ITestCaseRepository _testCaseRepository;

    public EditExerciseCommandHandler(IExerciseRepository exerciseRepository, ITestCaseRepository testCaseRepository)
    {
        _exerciseRepository = exerciseRepository;
        _testCaseRepository = testCaseRepository;
    }

    public async Task<OperationResult> Handle(EditExerciseCommand request, CancellationToken cancellationToken)
    {
        var (exerciseId, newTitle, newDescription, newTestCases)  = request;

        var exercise = await _exerciseRepository.GetExerciseByIdAsync(exerciseId, cancellationToken);
        if (exercise is null)
            return new DoesNotExist($"Exercise with id {exerciseId} not found");

        exercise.Title = newTitle;
        exercise.Description = newDescription;

        foreach (var oldTestCase in exercise.TestCases)
        {
            await _testCaseRepository.DeleteTestCaseAsync(oldTestCase, cancellationToken);
        }

        foreach (var (input, output) in newTestCases)
        {
            var newTestCase = new TestCase(exercise, input, output);
            await _testCaseRepository.CreateTestCaseAsync(newTestCase, cancellationToken);
        }

        await _exerciseRepository.SaveChangesAsync(cancellationToken);

        return new Success<Exercise>(exercise);
    }
}
