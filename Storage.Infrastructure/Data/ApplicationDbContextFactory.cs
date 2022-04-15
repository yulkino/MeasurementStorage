using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Storage.Infrastructure.Data;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    private readonly string _basePath = "D:/Garbage_Collector/Programming/Practice/Storage/Storage.Api";
    private readonly string _settingsFile = "appsettings.json";

    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(_basePath)
            .AddJsonFile(_settingsFile)
            .Build();
        var connectionString = configuration.GetConnectionString("MeasurementStorageDatabase");
        var dbContextBuild = new DbContextOptionsBuilder<ApplicationDbContext>()
            .UseSqlServer(connectionString);

        return new ApplicationDbContext(dbContextBuild.Options);
    }
}
