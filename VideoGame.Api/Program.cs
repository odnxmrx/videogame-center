
using VideoGame.Api.Entities;

// In-memory list of games
List<Game> games = new()
{
    new Game()
    {
        gameId = 1,
        Name = "Street Figther II",
        Genre = "Figthing",
        Price = 19.99M,
        ReleaseDate = new DateTime(1991, 2, 1),
        ImageUrl = "https://placehold.co/100"
    },
    new Game()
    {
        gameId = 2,
        Name = "Final Fantasy XIV",
        Genre = "Roleplaying",
        Price = 29.99M,
        ReleaseDate = new DateTime(2010, 9, 30),
        ImageUrl = "https://placehold.co/100"
    },
    new Game()
    {
        gameId = 3,
        Name = "FIFA 203",
        Genre = "Sports",
        Price = 59.99M,
        ReleaseDate = new DateTime(2022, 9, 27),
        ImageUrl = "https://placehold.co/100"
    },
    
};

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/games", () => games);

app.Run();
