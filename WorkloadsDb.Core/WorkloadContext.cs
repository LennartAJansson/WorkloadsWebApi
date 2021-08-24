namespace WorkloadsDb.Core
{
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Hosting;
    using Microsoft.Extensions.Logging;

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text.Json;
    using System.Text.Json.Serialization;
    using System.Threading.Tasks;

    using WorkloadsDb.Abstract;
    using WorkloadsDb.Model;

    public class WorkloadContext : DbContext, IUnitOfWork
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        private readonly Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private readonly ILoggerFactory loggerFactory;
        private readonly IHostEnvironment hostEnvironment;
        private ILogger<WorkloadContext> logger;

        public WorkloadContext(DbContextOptions<WorkloadContext> options, ILoggerFactory loggerFactory, IHostEnvironment hostEnvironment)
            : base(options)
        {
            this.loggerFactory = loggerFactory;
            this.hostEnvironment = hostEnvironment;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(loggerFactory);
            logger = loggerFactory.CreateLogger<WorkloadContext>();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().Property("Firstname").HasMaxLength(200);
        }

        public IGenericRepository<TEntity> Repository<TEntity>() where TEntity : class
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IGenericRepository<TEntity>;
            }

            IGenericRepository<TEntity> repo = new GenericRepository<TEntity>(this);

            repositories.Add(typeof(TEntity), repo);

            return repo;
        }

        public Task EnsureDbExists(bool seed = false)
        {
            var migrations = Database.GetPendingMigrations();

            if (migrations.Any())
            {
                logger.LogInformation("Adding migrations");
                Database.Migrate();
            }

            if (seed && hostEnvironment.IsDevelopment())
            {
                SeedSampleData();
            }

            return Task.CompletedTask;
        }

        public Task SeedSampleData()
        {
            if (File.Exists("sampledata.json"))
            {
                logger.LogInformation("Seeding data");
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    NumberHandling = JsonNumberHandling.AllowReadingFromString
                };
                IEnumerable<Person> people = JsonSerializer.Deserialize<IEnumerable<Person>>(File.ReadAllText("sampledata.json"), options);
                foreach (var person in people)
                {
                    People.Add(person);
                    SaveChanges();
                }
            }
            return Task.CompletedTask;
        }
    }
}
