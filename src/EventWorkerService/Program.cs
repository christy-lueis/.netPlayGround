using EventWorkerService;
using MydbServices.Interfaces;
using MydbServices.Models;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<Worker>();
//builder.Services.AddScoped<ICircle, Circle>();
var host = builder.Build();
host.Run();
