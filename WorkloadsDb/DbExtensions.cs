namespace WorkloadsDb
{
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;

    using WorkloadsDb.Abstract;

    public static class DbExtensions
    {
        public static IHost UpdateDb(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                scope.ServiceProvider.GetRequiredService<IUnitOfWork>().EnsureDbExists(true);
            }

            return host;
        }
    }
}
