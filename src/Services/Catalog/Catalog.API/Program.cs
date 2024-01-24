using Catalog.API;
using Common.Logging;
using Serilog;

var builder = WebApplication.CreateBuilder(args);
builder.Host.UseSerilog(Logging.configureLogger);
var startup = new Startup(builder.Configuration);
// Add services to the container.
startup.ConfigureServices(builder.Services);


var app = builder.Build();
startup.Configure(app, app.Environment);
// Configure the HTTP request pipeline.


app.Run();
