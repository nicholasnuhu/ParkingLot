using Microsoft.AspNetCore.HttpOverrides;
using ParkingLot.Api.Extensions;
using NLog;

var builder = WebApplication.CreateBuilder(args);

LogManager.Setup().LoadConfigurationFromFile(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
{
    // Add services to the container.
    builder.Services.ConfigureCors();
    builder.Services.ConfigureIISIntegrastion();
    builder.Services.AddControllers();
    builder.Services.ConfigureLoggerService();
}

var app = builder.Build();
{
    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
        app.UseDeveloperExceptionPage();
    else
        app.UseHsts();

    app.UseHttpsRedirection();

    app.UseStaticFiles();

    app.UseForwardedHeaders(new ForwardedHeadersOptions
    {
        ForwardedHeaders = ForwardedHeaders.All
    });

    app.UseCors("CorsPolicy");
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}

