using System;
using VideoGame.Api.Entities;

namespace VideoGame.Api.Repositories;

public class InMemGamesRepository : IGamesRepository
{

    // In-memory list of games
    private readonly List<Game> games = new()
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

    //retrieve all games
    public IEnumerable<Game> GetAll()
    {
        return games;
    }

    //Get single game
    public Game? Get(int id)
    {
        return games.Find(game => game.gameId == id); //"?" nullable value
    }

    //Create new
    public void Create(Game game)
    {
        game.gameId = games.Max(game => game.gameId) + 1; //assign max id val
        games.Add(game); //Add to list of 'games'
    }

    //Update
    public void Update(Game updatedGame)
    {
        var index = games.FindIndex(game => game.gameId == updatedGame.gameId);
        games[index] = updatedGame;
    }

    //Delete
    public void Delete(int id)
    {
        var index = games.FindIndex(game => game.gameId == id);
        games.RemoveAt(index);
    }

}
