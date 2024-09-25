using Microsoft.EntityFrameworkCore;
using VideoGame.Api.Data;
using VideoGame.Api.Endpoints;
using VideoGame.Api.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IGamesRepository, InMemGamesRepository>();

var connString = builder.Configuration.GetConnectionString("GameStoreContext");
builder.Services.AddSqlServer<GameStoreContext>(connString);

var app = builder.Build();

app.Services.InitializeDb(); //extending serv prov

app.MapGamesEndpoints();

app.Run();
