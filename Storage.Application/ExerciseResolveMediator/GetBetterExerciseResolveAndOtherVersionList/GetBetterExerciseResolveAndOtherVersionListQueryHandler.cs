using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseResolveMediator.GetBetterExerciseResolveAndOtherVersionList;

internal sealed class GetBetterExerciseResolveAndOtherVersionListQueryHandler : IOperationHandler<GetBetterExerciseResolveAndOtherVersionListQuery>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IExerciseResolveRepository _exerciseResolveRepository;
    private readonly IUserRepository _userRepository;

    public GetBetterExerciseResolveAndOtherVersionListQueryHandler(IExerciseRepository exerciseRepository,
        IExerciseResolveRepository exerciseResolveRepository, IUserRepository userRepository)
    {
        _exerciseRepository = exerciseRepository;
        _exerciseResolveRepository = exerciseResolveRepository;
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(GetBetterExerciseResolveAndOtherVersionListQuery request, CancellationToken cancellationToken)
    {
        var (userId, exerciseId) = request;

        var exercise = await _exerciseRepository.GetExerciseByIdAsync(exerciseId, cancellationToken);
        if (exercise is null)
            return new DoesNotExist($"Exercise with id {exerciseId} not found");

        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        if (user is null)
            return new DoesNotExist($"User with id {userId} not found");

        var exerciseResolvesByUser = await _exerciseResolveRepository.GetExerciseResolvesByConcreteTaskAsync(user, exercise, cancellationToken);

        var betterExerciseResolve = exerciseResolvesByUser.MinBy(er => er.ExecutionTime);
        var otherVersions = exerciseResolvesByUser.Except(new List<ExerciseResolve>() { betterExerciseResolve }).ToList();

        return new Success<(ExerciseResolve, List<ExerciseResolve>)>((betterExerciseResolve, otherVersions));
    }
}
