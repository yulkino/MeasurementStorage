using MediatR;
using Storage.Application.Repositories;
using Storage.Domain.ExerciseData;

namespace Storage.Application.ExerciseMediator.GetExerciseList;

internal sealed class GetExerciseListHandler : IRequestHandler<GetExerciseListQuery, List<Exercise>>
{
    private readonly IExerciseRepository _exerciseRepository;

    public GetExerciseListHandler(IExerciseRepository exerciseRepository)
    {
        _exerciseRepository = exerciseRepository;
    }

    public Task<List<Exercise>> Handle(GetExerciseListQuery request, CancellationToken cancellationToken)
        => _exerciseRepository.GetAllExercisesAsync(cancellationToken);
}
