using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Ocelot.Values;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Configuration.AddJsonFile($"ocelot.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true);
builder.Services.AddOcelot(builder.Configuration)
    .AddCacheManager(settings => settings.WithDictionaryHandle());
var userPolicy = new AuthorizationPolicyBuilder()
.RequireAuthenticatedUser()
                .Build();
var authScheme = "IFShoppingGatewayAuthScheme";
builder.Services.AddControllers(config => config.Filters.Add(new AuthorizeFilter(userPolicy)));
builder.Services.AddCors(options =>
{
    options.AddPolicy("Local", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .WithOrigins("http://localhost:4200");
    });
});

//builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
//    .AddJwtBearer(authScheme,options =>
//    {
//        options.Authority = "https://localhost:9009";
//        options.Audience = "IFShopping";
//    });
//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("CanRead", policy => policy.RequireClaim("scope", "catalogapi.read"));
//});

var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.UseRouting();
app.UseCors("Local");
app.UseEndpoints(endpoints => endpoints.MapControllers());
await app.UseOcelot();

app.Run();
