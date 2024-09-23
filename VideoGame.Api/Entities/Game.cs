using System.ComponentModel.DataAnnotations;
namespace VideoGame.Api.Entities;

public class Game
{
  public int gameId { get; set; }
  
  [Required]
  [StringLength(80)]
  public required string Name { get; set; }
  
  [Required]
  [StringLength(50)]
  public required string Genre { get; set; }
  
  [Range(1,100)]
  public decimal Price { get; set; }
  public DateTime ReleaseDate { get; set; }

  [Url]
  [StringLength(120)]
  public required string ImageUrl { get; set; }
}
