


using Microsoft.EntityFrameworkCore;
using PruebaTecnicaBack.application.repositories;
using PruebaTecnicaBack.infrastructure.repositories;

namespace PruebaTecnicaBack.infrastructure
{
    public static class infrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(opts =>
                opts.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    x => x.MigrationsHistoryTable("__EFMigrationHistory", "store")
                    )
                );
            
            services.AddScoped<IStoreRepository, StoreRepository>();

            

            return services;
        }
    }
}