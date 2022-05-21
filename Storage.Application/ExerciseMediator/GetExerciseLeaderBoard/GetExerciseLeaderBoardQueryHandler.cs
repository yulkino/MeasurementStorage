using Storage.Application.Repositories;
using Storage.Application.Results;

namespace Storage.Application.ExerciseMediator.GetExerciseLeaderBoard;

internal sealed class GetExerciseLeaderBoardQueryHandler : IOperationHandler<GetExerciseLeaderBoardQuery>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IExerciseResolveRepository _exerciseResolveRepository;

    public GetExerciseLeaderBoardQueryHandler(IExerciseRepository exerciseRepository, IExerciseResolveRepository exerciseResolveRepository)
    {
        _exerciseRepository = exerciseRepository;
        _exerciseResolveRepository = exerciseResolveRepository;
    }

    public Task<OperationResult> Handle(GetExerciseLeaderBoardQuery request, CancellationToken cancellationToken)
    {
        //TODO
        throw new NotImplementedException();
    }
}
