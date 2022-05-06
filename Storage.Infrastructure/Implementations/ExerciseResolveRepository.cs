using Microsoft.EntityFrameworkCore;
using Storage.Application.Repositories;
using Storage.Domain.ExerciseData;
using Storage.Domain.UserData;
using Storage.Infrastructure.Data;

namespace Storage.Infrastructure.Implementations;

public class ExerciseResolveRepository : IExerciseResolveRepository
{
    private readonly ApplicationDbContext _context;

    public ExerciseResolveRepository(ApplicationDbContext context)
    {
        _context = context;
    }

    public Task CreateExerciseResolveAsync(ExerciseResolve exerciseResolve, CancellationToken cancellationToken)
        => _context.ExercisesResolves.AddAsync(exerciseResolve, cancellationToken).AsTask();

    public Task<ExerciseResolve?> GetExerciseResolvesByIdAsync(Guid id, CancellationToken cancellationToken)
        => _context.ExercisesResolves.FindAsync(id, cancellationToken).AsTask();

    public Task<List<ExerciseResolve>> GetExerciseResolvesByUserAsync(User user, CancellationToken cancellationToken)
        => _context.ExercisesResolves.Where(e => e.User == user).ToListAsync(cancellationToken);

    public Task SaveExerciseResolveChangesAsync(CancellationToken cancellationToken)
        => _context.SaveChangesAsync(cancellationToken);
}
