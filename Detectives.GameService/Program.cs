using Detectives.GameService.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSignalR();

var app = builder.Build();

app.MapHub<GameHub>("/game");

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
