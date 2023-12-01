using Microsoft.Extensions.Options;
using ParkingLot.Core.Interfaces;
using ParkingLot.Infrastructure.ExternalService;

namespace ParkingLot.Api.Extensions;

public static class ServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());
            });

    public static void ConfigureIISIntegrastion(this IServiceCollection services) =>
        services.Configure<IISOptions>(Options =>
        {

        });

    public static void ConfigureLoggerService(this IServiceCollection services) =>
        services.AddSingleton<ILoggerService, LoggerService>();
}