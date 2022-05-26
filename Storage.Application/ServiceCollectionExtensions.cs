using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace Storage.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services) 
        => services.AddMediatR(typeof(ServiceCollectionExtensions))
            .AddScoped<IResolveTimeMeasurer, ResolveTimeMeasurer>();
}