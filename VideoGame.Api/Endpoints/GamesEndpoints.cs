using System.Linq;
using VideoGame.Api.Dto;
using VideoGame.Api.Entities;
using VideoGame.Api.Repositories;

namespace VideoGame.Api.Endpoints;

public static class GamesEndpoints //essential extension method (static)
{
    const string GetGameEndpointName = "GetGame"; //const to endpoint definition

    //endopoint management method - 'MapGamesEndpoints'
    public static RouteGroupBuilder MapGamesEndpoints(this IEndpointRouteBuilder routes)
    //'this' to implement this existing Method and extend it, as 'routes'
    {

        var routeGroup = routes.MapGroup("/games") //Defining map group for routes
                    .WithParameterValidation(); //from NuGet 'MinimalApis.Extensions'

        //GET All 
        routeGroup.MapGet("/", (IGamesRepository repository) => 
            repository.GetAll() //getting all 'games'
            .Select(game => game.AsDto())); //transform into Dto obj.
            //'.AsDto()' -> thus we no longer return entities to the client, but only Dto.

        //GET by {id}
        routeGroup.MapGet("/{id}", (IGamesRepository repository, int id) => 
        {
            Game? game = repository.Get(id); //games.Find(game => game.gameId == id); //"?" nullable value

            return game is not null ? Results.Ok(game.AsDto()) : Results.NotFound();
        })
        .WithName(GetGameEndpointName); //specify a name for our endopoint

        //POST new game
        routeGroup.MapPost("/", (IGamesRepository repository, CreateGameDto gameDto) => {
            
            Game game = new() //we need to create the obj to send it:
            {   //defining our entity properties:
                Name = gameDto.Name,
                Genre = gameDto.Genre,
                Price = gameDto.Price,
                ReleaseDate = gameDto.ReleaseDate,
                ImageUrl = gameDto.ImageUri

            };
            
            repository.Create(game);
            return Results.CreatedAtRoute(GetGameEndpointName, new {id = game.gameId}, game);
            /*
            1st arg -> endpoint name
            2nd arg -> anon obj def for the needed Id
            3rd arg -> the entire obj just created
            */
        });

        //PUT existing game
        routeGroup.MapPut("/{givenId}", (IGamesRepository repository, int givenId, UpdateGameDto updatedGameDto) => {

            Game? existingGame = repository.Get(givenId); //games.Find(game => game.gameId == givenId); //"?" nullable value

            if(existingGame is null) //validate null value
            {
                return Results.NotFound(); //TO RE-WORK
            }

            existingGame.Name = updatedGameDto.Name;
            existingGame.Genre = updatedGameDto.Genre;
            existingGame.Price = updatedGameDto.Price;
            existingGame.ReleaseDate = updatedGameDto.ReleaseDate;
            existingGame.ImageUrl = updatedGameDto.ImageUri;
            
            repository.Update(existingGame); //execute updating

            return Results.NoContent(); //usual with PUT
        });

        //DELETE method
        routeGroup.MapDelete("/{givenId}", (IGamesRepository repository, int givenId) => {
            Game? givenGame = repository.Get(givenId); //games.Find(game => game.gameId == givenId); //"?" nullable value

            if(givenGame is not null) //validate not null value
            {
                repository.Delete(givenId); //games.Remove(givenGame);
            }

            return Results.NoContent(); //return no-content anyway
        });

        return routeGroup; //our RouteGroupBuilder
    }
}
