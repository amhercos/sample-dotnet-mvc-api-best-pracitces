using Microsoft.AspNetCore.RateLimiting;
using Microsoft.OpenApi;
using System.Threading.RateLimiting;

namespace MvcApi.Extensions;

public static class WebApplicationBuilderExtensions
{
    //Swagger documentation
    public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(options =>
        {
            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "MvcApi Product Portal",
                Version = "v1"
            });
        });

        return services;
    }

    // Rate limiter
    public static IServiceCollection AddCustomRateLimiter(this IServiceCollection services)
    {
        services.AddRateLimiter(options =>
        {
            options.AddFixedWindowLimiter(policyName: "FixedWindowPolicy", fixedOptions =>
            {
                fixedOptions.PermitLimit = 10;
                fixedOptions.Window = TimeSpan.FromSeconds(10);
                fixedOptions.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                fixedOptions.QueueLimit = 2;
            });

            options.OnRejected = async (context, token) =>
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status429TooManyRequests;
                context.HttpContext.Response.ContentType = "application/json";

                await context.HttpContext.Response.WriteAsJsonAsync(new
                {
                    message = "Too many requests. Please slow down and try again later."
                }, token);
            };
        });

        return services;
    }
}