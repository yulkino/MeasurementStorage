using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.CreateExercise;

internal sealed class CreateExerciseCommandHandler : IOperationHandler<CreateExerciseCommand>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUserRepository _userRepository;
    private readonly ITestCaseRepository _testCaseRepository;

    public CreateExerciseCommandHandler(IExerciseRepository exerciseRepository, IUserRepository userRepository, ITestCaseRepository testCaseRepository)
    {
        _exerciseRepository = exerciseRepository;
        _userRepository = userRepository;
        _testCaseRepository = testCaseRepository;
    }

    public async Task<OperationResult> Handle(CreateExerciseCommand request, CancellationToken cancellationToken)
    {
        var (title, description, testCases, authorId, creationDate) = request;

        var user = await _userRepository.GetUserByIdAsync(authorId, cancellationToken);
        if (user is null)
            return new DoesNotExist($"User with id {authorId} not found.");

        var exercise = new Exercise(title, description, user, creationDate);

        foreach (var (input, output) in testCases)
        {
            var testCase = new TestCase(exercise, input, output);
            await _testCaseRepository.CreateTestCaseAsync(testCase, cancellationToken);
        }

        await _exerciseRepository.CreateExerciseAsync(exercise, cancellationToken);
        await _exerciseRepository.SaveChangesAsync(cancellationToken);

        return new Created<Exercise>(exercise);
    }
}
