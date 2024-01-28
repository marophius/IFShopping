using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Ocelot.Values;
using Common.Logging.Correlation;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration)
    .AddCacheManager(settings => settings.WithDictionaryHandle());
builder.Services.AddCors(options =>
{
    options.AddPolicy("Local", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:4200");
    });
});

builder.Services.AddScoped<ICorrelationIdGenerator, CorrelationIdGenerator>();

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.AddCorrelationMiddleware();
app.UseRouting();
app.UseCors("Local");
app.UseEndpoints(endpoints => endpoints.MapControllers());
await app.UseOcelot();

app.Run();
