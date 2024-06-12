using Detectives.Sessions.Infrastructure;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<GameSessionsDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection"));
});

builder.Services.AddMassTransit(conf =>
{
    conf.SetKebabCaseEndpointNameFormatter();
    conf.SetInMemorySagaRepositoryProvider();

    var assembly = typeof(Program).Assembly;

    conf.AddConsumers(assembly);
    conf.AddSagaStateMachines(assembly);
    conf.AddSagas(assembly);
    conf.AddActivities(assembly);

    conf.UsingInMemory();
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
