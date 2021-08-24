namespace WorkloadsDb.Core
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Design;
    using Microsoft.Extensions.Logging;

    public class WorkloadContextFactory : IDesignTimeDbContextFactory<WorkloadContext>
    {
        public static readonly ILoggerFactory MyLoggerFactory = LoggerFactory.Create(builder => { builder.AddConsole(); });
        public WorkloadContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<WorkloadContext>();
            optionsBuilder.UseSqlServer("server=localhost\\SQLEXPRESS;database=tempworkloads;User Id=sa;Password=Nisse1234!;");
            optionsBuilder.UseLoggerFactory(MyLoggerFactory);

            return new WorkloadContext(optionsBuilder.Options, MyLoggerFactory);
        }
    }
}
