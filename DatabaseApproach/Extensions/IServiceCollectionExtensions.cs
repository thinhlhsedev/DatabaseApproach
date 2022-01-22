
using DatabaseApproach.Domain.Repository;
using DBApproach.Business.Services;
using DBApproach.Domain.Interfaces;
using DBApproach.Infrastructure;
using DBApproach.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace DatabaseApproach.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            // Configure DbContext with Scoped lifetime
            services.AddDbContext<TestDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("TestDatabase"));
            });

            services.AddScoped<Func<TestDbContext>>((provider) => () => provider.GetService<TestDbContext>());
            services.AddScoped<DbFactory>();

            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IAccountRepository, AccountRepository>()
                .AddScoped<IAttendanceRepository, AttendanceRepository>()
                .AddScoped<IComponentRepository, ComponentRepository>(); ;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            return services.AddScoped<AccountService>()
                .AddScoped<AttendanceService>()
                .AddScoped<ComponentService>();
        }
    }
}
