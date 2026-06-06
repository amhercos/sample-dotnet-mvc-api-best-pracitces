using Microsoft.EntityFrameworkCore;
using MvcApi.Data;
using MvcApi.Repositories.Implementations;
using MvcApi.Repositories.Interface;

namespace MvcApi.Extensions
{
    public static class InfrastructureServiceExtensions
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services, 
            IConfiguration config)
        {
            var connectionString = config.GetConnectionString("DefaultConnection");
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddScoped<IProductRepository, ProductRepository>();
            return services;
        }
    }
}
