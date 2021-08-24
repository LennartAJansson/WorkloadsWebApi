namespace WorkloadsDb
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;

    using WorkloadsDb.Abstract;
    using WorkloadsDb.Core;

    public static class ContextExtensions
    {
        public static IServiceCollection AddWorkloadContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IUnitOfWork, WorkloadContext>(builder =>
            {
                builder.UseSqlServer(configuration.GetConnectionString("WorkloadDb"));
            });
            services.AddScoped<IWorkloadService, WorkloadService>();

            return services;
        }
    }
}
