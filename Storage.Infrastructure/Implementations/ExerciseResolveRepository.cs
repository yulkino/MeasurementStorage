using Microsoft.EntityFrameworkCore;
using Storage.Application.Repositories;
using Storage.Domain.ExerciseData;
using Storage.Domain.UserData;
using Storage.Infrastructure.Data;

namespace Storage.Infrastructure.Implementations;

internal class ExerciseResolveRepository : Repository, IExerciseResolveRepository
{
    public ExerciseResolveRepository(ApplicationDbContext context) : base(context) { }

    public Task CreateExerciseResolveAsync(ExerciseResolve exerciseResolve, CancellationToken cancellationToken)
        => Context.ExercisesResolves.AddAsync(exerciseResolve, cancellationToken).AsTask();

    public Task<ExerciseResolve?> GetExerciseResolvesByIdAsync(Guid id, CancellationToken cancellationToken)
        => Context.ExercisesResolves.FindAsync(id, cancellationToken).AsTask();

    public Task<List<ExerciseResolve>> GetExerciseResolvesByUserAsync(User user, CancellationToken cancellationToken)
        => Context.ExercisesResolves
            .Where(o => o == Context.ExercisesResolves
                .Where(x => x.User == user && x.Exercise == o.Exercise)
                .MinBy(x => x.ExecutionTime))
            .ToListAsync(cancellationToken);

    public Task<List<ExerciseResolve>> GetExerciseResolvesByConcreteTaskAsync(User user, Exercise exercise,
        CancellationToken cancellationToken)
        => Context.ExercisesResolves.Where(er => er.User == user || er.Exercise == exercise)
            .ToListAsync(cancellationToken);
}
