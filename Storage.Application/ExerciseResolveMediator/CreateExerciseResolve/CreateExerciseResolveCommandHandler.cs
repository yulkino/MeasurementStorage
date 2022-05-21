using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseResolveMediator.CreateExerciseResolve;

internal sealed class CreateExerciseResolveCommandHandler : IOperationHandler<CreateExerciseResolveCommand>
{
    private readonly IExerciseResolveRepository _exerciseResolveRepository;
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUserRepository _userRepository;
    private readonly IResolveTimeMeasurer _resolveTimeMeasurer;

    public CreateExerciseResolveCommandHandler(IExerciseResolveRepository exerciseResolveRepository, IExerciseRepository exerciseRepository, IUserRepository userRepository, IResolveTimeMeasurer timeMeasurer)
    {
        _exerciseResolveRepository = exerciseResolveRepository;
        _exerciseRepository = exerciseRepository;
        _userRepository = userRepository;
        _resolveTimeMeasurer = timeMeasurer;
    }

    public async Task<OperationResult> Handle(CreateExerciseResolveCommand request, CancellationToken cancellationToken)
    {
        var (exerciseId, userId, resolve, sendingDate) = request;

        var exercise = await _exerciseRepository.GetExerciseByIdAsync(exerciseId, cancellationToken);
        if (exercise is null)
            return new DoesNotExist($"Exercise with id {exerciseId} not found");

        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        if (user is null)
            return new DoesNotExist($"User with id {userId} not found");

        var estimatedTime = await _resolveTimeMeasurer.MeasureAsync(exercise, resolve);

        var exerciseResolve = new ExerciseResolve(exercise, user, resolve, sendingDate, estimatedTime);
        await _exerciseResolveRepository.CreateExerciseResolveAsync(exerciseResolve, cancellationToken);
        await _exerciseResolveRepository.SaveChangesAsync(cancellationToken);

        return new Created<ExerciseResolve>(exerciseResolve);
    }
}
