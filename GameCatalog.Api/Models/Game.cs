namespace GameCatalog.Api.Models;

public enum Platform { PC = 0, PlayStation = 1, Xbox = 2, Switch = 3 }

public class Game
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Platform Platform { get; set; } = Platform.PC;
    public string Genre { get; set; } = string.Empty;
    public decimal Price { get; set; }
    public DateOnly? ReleaseDate { get; set; }
}