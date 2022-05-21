using Storage.Application.Repositories;
using Storage.Application.Results;

namespace Storage.Application.ExerciseMediator.GetExerciseStatistics;

internal sealed class GetExerciseStatisticsQueryHandler : IOperationHandler<GetExerciseStatisticsQuery>
{
    private readonly IExerciseRepository _exerciseRepository;
    private readonly IExerciseResolveRepository _exerciseResolveRepository;

    public GetExerciseStatisticsQueryHandler(IExerciseRepository exerciseRepository, IExerciseResolveRepository exerciseResolveRepository)
    {
        _exerciseRepository = exerciseRepository;
        _exerciseResolveRepository = exerciseResolveRepository;
    }

    public Task<OperationResult> Handle(GetExerciseStatisticsQuery request, CancellationToken cancellationToken)
    {
        //TODO
        throw new NotImplementedException();
    }
}
