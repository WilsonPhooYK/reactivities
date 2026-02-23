using Microsoft.EntityFrameworkCore;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(opt =>
{
  opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapControllers();

// using keyword to create a scope for the db context, so it will be disposed after use immediately
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;

try
{
  // Get access to the db context
  var context = services.GetRequiredService<AppDbContext>();
  // Run any pending migrations, create the database if not exist
  await context.Database.MigrateAsync();
  // Seed the database with initial data if there is no data
  await DbInitializer.SeedData(context);
}
catch (Exception ex)
{
  var logger = services.GetRequiredService<ILogger<Program>>();
  logger.LogError(ex, "An error occurred during migration");
}

app.Run();
