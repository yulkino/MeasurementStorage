using Storage.Application.Repositories;
using Storage.Infrastructure.Data;

namespace Storage.Infrastructure.Implementations;

internal abstract class Repository : IRepository
{
    protected readonly ApplicationDbContext Context;

    protected Repository(ApplicationDbContext context)
    {
        Context = context;
    }

    public Task SaveChangesAsync(CancellationToken cancellationToken)
        => Context.SaveChangesAsync(cancellationToken);
}
