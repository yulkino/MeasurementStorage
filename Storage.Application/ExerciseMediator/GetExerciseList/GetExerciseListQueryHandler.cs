using Storage.Application.Repositories;
using Storage.Application.Results;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.GetExerciseList;

internal sealed class GetExerciseListQueryHandler : IOperationHandler<GetExerciseListQuery>
{
    private readonly IExerciseRepository _exerciseRepository;

    public GetExerciseListQueryHandler(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public async Task<OperationResult> Handle(GetExerciseListQuery request, CancellationToken cancellationToken)
        => new Success<List<Exercise>>(await _exerciseRepository.GetAllExercisesAsync(cancellationToken));
}
