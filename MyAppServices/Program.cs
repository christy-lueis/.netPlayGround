using Log.Data;
using Log.Interfaces;
using Log.Services;
using Microsoft.EntityFrameworkCore;
using middleware.Services;
using MydbServices.Data;

var builder = WebApplication.CreateBuilder(args);


var config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();
string EnvironmentString = builder.Configuration.GetConnectionString("Environment");
config = new ConfigurationBuilder()
    .SetBasePath(AppContext.BaseDirectory)
    .AddConfiguration(config) // Add base config
    .AddJsonFile($"appsettings.{EnvironmentString}.json", optional: true)
    .Build();
// Add services to the container.


builder.Services.AddControllers();

builder.Services.AddDbContext<AreaDbContext>(options => options.UseSqlServer(config.GetConnectionString("AreaDBconnectionString") ?? throw new InvalidOperationException("Connection string 'AreaDbContext' not found.")));
builder.Services.AddDbContext<LogDbContext>(options => options.UseSqlServer(config.GetConnectionString("AreaDBconnectionString") ?? throw new InvalidOperationException("Connection string 'LogDbContext' not found.")));


// Add services to the container.

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ILogging, LoggingService>();
//builder.Services.AddScoped<IArea, Circle>();
//builder.Services.AddScoped<IArea, Square>();
//builder.Services.AddScoped<IArea, Rectangle>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseRouting();
app.Use(async (context, next) =>
{
    context.Request.EnableBuffering();
    await next();
});
app.UseCustomMiddleware();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

app.Run();
