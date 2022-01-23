using DBApproach.Domain.Repository;
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
            //Configure Interface vs Repo
            return services
                .AddScoped(typeof(IRepository<>), typeof(Repository<>))
                .AddScoped<IAccountRepository, AccountRepository>()
                .AddScoped<IAttendanceRepository, AttendanceRepository>()
                .AddScoped<IAttendanceDetailRepository, AttendanceDetailRepository>()
                .AddScoped<IComponentRepository, ComponentRepository>()
                .AddScoped<IMaterialRepository, MaterialRepository>()
                .AddScoped<IProductRepository, ProductRepository>()
                .AddScoped<IOrderRepository, OrderRepository>()
                .AddScoped<IOrderDetailRepository, OrderDetailRepository>()
                .AddScoped<IProcessRepository, ProcessRepository>()
                .AddScoped<IRoleRepository, RoleRepository>()
                .AddScoped<IProductComponentRepository, ProductComponentRepository>()
                .AddScoped<IComponentMaterialRepository, ComponentMaterialRepository>()
                .AddScoped<IImportExportRepository, ImportExportRepository>();
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            //Add service
            return services.AddScoped<AccountService>()
                .AddScoped<AttendanceService>()
                .AddScoped<AttendanceDetailService>()
                .AddScoped<ComponentService>()
                .AddScoped<MaterialService>()
                .AddScoped<ProductService>()
                .AddScoped<OrderService>()
                .AddScoped<OrderDetailService>()
                .AddScoped<ProcessService>()
                .AddScoped<RoleService>()
                .AddScoped<ProductComponentService>()
                .AddScoped<ComponentMaterialService>()
                .AddScoped<ImportExportService>();
        }
    }
}
