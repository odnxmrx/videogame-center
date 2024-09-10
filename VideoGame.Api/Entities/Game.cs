using System;

namespace VideoGame.Api.Entities;

public class Game
  {
  public int gameId { get; set; }
  public required string Name { get; set; }
  public required string Genre { get; set; }
  public decimal Price { get; set; }
  public DateTime ReleaseDate { get; set; }
  public required string ImageUrl { get; set; }
}
