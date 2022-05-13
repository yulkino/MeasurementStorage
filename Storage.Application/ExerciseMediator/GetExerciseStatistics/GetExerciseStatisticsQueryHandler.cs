using MediatR;
using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.GetExerciseStatistics;

internal sealed class GetExerciseStatisticsQueryHandler : IOperationHandler<GetExerciseStatisticsQuery>
{
    private readonly IExerciseRepository _exerciseRepository;

    public GetExerciseStatisticsQueryHandler(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public Task<OperationResult> Handle(GetExerciseStatisticsQuery request, CancellationToken cancellationToken)
    {
        //TODO
        return null;
    }
}
