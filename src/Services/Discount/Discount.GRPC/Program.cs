//using Discount.GRPC.Services;

using Discount.GRPC.Extensions;
using Discount.Infrastructure;
using Discount.Application;
using Discount.GRPC.Services;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddInfrastructure();
builder.Services.AddApplication();
var app = builder.Build();
app.MigrateDatabase<Program>();
app.UseDeveloperExceptionPage();
// Configure the HTTP request pipeline.
app.MapGrpcService<DiscountService>();


app.Run();
