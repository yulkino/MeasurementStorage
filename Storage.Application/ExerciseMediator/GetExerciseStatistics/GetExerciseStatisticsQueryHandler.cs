using MediatR;
using Storage.Application.Repositories;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.GetExerciseStatistics;

internal sealed class GetExerciseStatisticsQueryHandler : IRequestHandler<GetExerciseStatisticsQuery, List<Exercise>>
{
    private readonly IExerciseRepository _exerciseRepository;

    public GetExerciseStatisticsQueryHandler(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public Task<List<Exercise>> Handle(GetExerciseStatisticsQuery request, CancellationToken cancellationToken)
    {
        //TODO
        return null;
    }
}
