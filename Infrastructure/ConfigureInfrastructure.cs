using Application.Mapper;
using Application.UseCases.Job.Create;
using Core;
using Core.RepositoriesInterfaces;
using FluentMigrator.Runner;
using Infrastructure.Data.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Infrastructure
{
    public class ConfigureInfrastructure
    {
        public static void ConfigureRepositories(IServiceCollection services)
        {
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
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

        public static void ConfigureMediatR(IServiceCollection services)
        {
            services.AddMediatR(cfg =>
                cfg.RegisterServicesFromAssembly(typeof(ConfigureApplication).Assembly));
            services.AddTransient<ICreateJobUseCase, CreateJobUseCase>();
            services.AddTransient<CreateJobCommandValidator>();
            services.AddTransient<CreateJobCommand>();
            services.AddSingleton<JobMapper>();
        }

        public static void ConfigureAuthentication(IServiceCollection services, IConfiguration configuration)
        {
            var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"]);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true
                };
            });
        }
    }
}
