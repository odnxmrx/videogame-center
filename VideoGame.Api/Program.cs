using VideoGame.Api.Endpoints;
using VideoGame.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();

var app = builder.Build();

app.MapGamesEndpoints();

app.Run();
