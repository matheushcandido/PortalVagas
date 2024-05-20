using Application.Mapper;
using Core.RepositoriesInterfaces;
using FluentMigrator.Runner;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure
{
    public class ConfigureInfrastructure
    {
        public static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IJobRepository, JobRepository>();
        }

        public static void ConfigureMigrator(IServiceCollection services, string connectionString)
        {
            services.AddFluentMigratorCore()
                    .ConfigureRunner(rb => rb
                        .AddSqlServer()
                        .WithGlobalConnectionString(connectionString)
                        .ScanIn(typeof(ConfigureInfrastructure).Assembly).For.Migrations())
                    .AddLogging(lb => lb.AddFluentMigratorConsole());
        }
    }
}