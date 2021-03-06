using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseResolveMediator.GetExerciseResolveListOfUser;

internal sealed class GetExerciseResolveListOfUserQueryHandler : IOperationHandler<GetExerciseResolveListOfUserQuery>
{
    private readonly IExerciseResolveRepository _exerciseResolveRepository;
    private readonly IUserRepository _userRepository;

    public GetExerciseResolveListOfUserQueryHandler(IExerciseResolveRepository exerciseResolveRepository, IUserRepository userRepository)
    {
        _exerciseResolveRepository = exerciseResolveRepository;
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(GetExerciseResolveListOfUserQuery request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        if (user is null)
            throw new ArgumentException($"User with id {userId} not found");

        var exerciseResolves = await _exerciseResolveRepository.GetExerciseResolvesByUserAsync(user, cancellationToken);

        return new Success<List<ExerciseResolve>>(exerciseResolves);
    }
}
