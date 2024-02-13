namespace Codesaurs.Models;

public class Course
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? ShortDescription { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public decimal? Price { get; set; }
    public decimal? Duration { get; set; }
    public string? Level { get; set; }
    public string? Language { get; set; }
    public List<string>? Chips { get; set; } = new List<string>();
    public int? Views { get; set; }
}