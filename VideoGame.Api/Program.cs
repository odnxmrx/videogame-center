
using VideoGame.Api.Entities;

//const to endpoint definition
const string GetGameEndpointName = "GetGame";

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

//GET All 
app.MapGet("/games", () => games);

//GET by {id}
app.MapGet("/games/{id}", (int id) => 
{
    Game? game = games.Find(game => game.gameId == id); //"?" nullable value

    if(game is null) //validate not null value
    {
        return Results.NotFound();
    }
    return Results.Ok(game);
})
.WithName(GetGameEndpointName); //specify a name for our endopoint

//POST new game
app.MapPost("/games", (Game game) => {
    game.gameId = games.Max(game => game.gameId) + 1; //assign max id val
    games.Add(game); //Add to list of 'games'

    return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.gameId}, game);
    /*
    1st arg -> endpoint name
    2nd arg -> anon obj def for the needed Id
    3rd arg -> the entire obj just created
    */
});

//PUT existing game
app.MapPut("/games/{givenId}", (int givenId, Game updatedGame) => {

    Game? existingGame = games.Find(game => game.gameId == givenId); //"?" nullable value

    if(existingGame is null) //validate null value
    {
        return Results.NotFound(); //TO RE-WORK
    }

    existingGame.Name = updatedGame.Name;
    existingGame.Genre = updatedGame.Genre;
    existingGame.Price = updatedGame.Price;
    existingGame.ReleaseDate = updatedGame.ReleaseDate;
    existingGame.ImageUrl = updatedGame.ImageUrl;
    
    return Results.NoContent(); //usual with PUT
});

//DELETE method
app.MapDelete("/games/{givenId}", (int givenId) => {
    Game? givenGame = games.Find(game => game.gameId == givenId); //"?" nullable value

    if(givenGame is not null) //validate not null value
    {
        games.Remove(givenGame);
    }

    return Results.NoContent(); //return no-content anyway
});

app.Run();
