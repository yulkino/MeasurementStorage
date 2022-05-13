using MediatR;
using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.GetExerciseListOfUser;

internal sealed class GetExerciseListOfUserQueryHandler : IOperationHandler<GetExerciseListOfUserQuery>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IUserRepository _userRepository;

    public GetExerciseListOfUserQueryHandler(IExerciseRepository exerciseRepository, IUserRepository userRepository)
    {
        _exerciseRepository = exerciseRepository;
        _userRepository = userRepository;
    }

    public async Task<OperationResult> Handle(GetExerciseListOfUserQuery request, CancellationToken cancellationToken)
    {
        var userId = request.UserId;
        var user = await _userRepository.GetUserByIdAsync(userId, cancellationToken);
        if (user is null)
            return new DoesNotExist($"User with id {userId} not found");

        var exercises = await _exerciseRepository.GetExercisesByAuthorAsync(user, cancellationToken);

        return new Success<List<Exercise>>(exercises);
    }
}
