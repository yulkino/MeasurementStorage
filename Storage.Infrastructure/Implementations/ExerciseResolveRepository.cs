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
                .OrderBy(x => x.ExecutionTime)
                .FirstOrDefault(x => x.User == user && x.Exercise == o.Exercise))
            .ToListAsync(cancellationToken);

    public Task SaveExerciseResolveChangesAsync(CancellationToken cancellationToken)
        => Context.SaveChangesAsync(cancellationToken);
}
