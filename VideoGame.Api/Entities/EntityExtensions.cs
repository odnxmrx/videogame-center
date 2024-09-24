using System;
using VideoGame.Api.Dto;

namespace VideoGame.Api.Entities;

//Method to easily map (convert) Game entity to its Dto:
public static class EntityExtensions //Extensions are 'static'
{
    public static GameDto AsDto(this Game game) // we're extending the Game entity ('this Game' called 'game')
    {
        return new GameDto( //new instance of the Dto based on 'game' values
            game.gameId,
            game.Name,
            game.Genre,
            game.Price,
            game.ReleaseDate,
            game.ImageUrl
        );
    }
}
