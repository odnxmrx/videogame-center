using System.ComponentModel.DataAnnotations;

namespace VideoGame.Api.Dto;

public record GameDto //get - retreiving game
( 
    int Id,
    string Name,
    string Genre,
    decimal Price,
    DateTime ReleaseDate,
    string ImageUri
);

public record CreateGameDto //post - create game
( 
    [Required][StringLength(80)] string Name,
    [Required][StringLength(50)] string Genre,
    [Range(1,100)] decimal Price,
    DateTime ReleaseDate,
    [Url][StringLength(120)] string ImageUri
);

public record UpdateGameDto //put - update game
( 
    [Required][StringLength(80)] string Name,
    [Required][StringLength(50)] string Genre,
    [Range(1,100)] decimal Price,
    DateTime ReleaseDate,
    [Url][StringLength(120)] string ImageUri
); 
/*these 2 records may be the same rn, but requirements could change.
so, we do want to keep them separate */
