//using Discount.GRPC.Services;

using Discount.GRPC.Extensions;
using Discount.Infrastructure;
using Discount.Application;
using Discount.GRPC.Services;
using Serilog;
using Common.Logging;
var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog(Logging.configureLogger);
// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
var app = builder.Build();
app.MapGrpcService<DiscountService>();
// Configure the HTTP request pipeline.
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");
app.MigrateDatabase<Program>();

app.Run();
