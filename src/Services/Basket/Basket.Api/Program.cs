
using Basket.Api;
using Common.Logging;
using Microsoft.Extensions.Logging.Configuration;
using Serilog;
var builder = WebApplication.CreateBuilder(args);
var startup = new Startup(builder.Configuration);
builder.Host.UseSerilog(Logging.configureLogger);
// Add services to the container.
startup.ConfigureServices(builder.Services);

var app = builder.Build();
startup.Configure(app, app.Environment);
// Configure the HTTP request pipeline.

