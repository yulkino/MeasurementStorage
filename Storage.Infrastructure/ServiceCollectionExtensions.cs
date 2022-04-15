using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Storage.Infrastructure.Data;

namespace Storage.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static void AddInfrastructure(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(connectionString));
    }
}
