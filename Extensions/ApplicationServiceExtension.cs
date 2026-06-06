using MvcApi.Services.Implementations;
using MvcApi.Services.Interface;

namespace MvcApi.Extensions
{
    public static class ApplicationServiceExtension
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            // Register your services here
            services.AddScoped<IProductService, ProductService>();
            return services;
        }
    }
}
