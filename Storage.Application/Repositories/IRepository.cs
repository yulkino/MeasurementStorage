namespace Storage.Application.Repositories;

public interface IRepository
{
    Task SaveChangesAsync(CancellationToken cancellationToken);
}
