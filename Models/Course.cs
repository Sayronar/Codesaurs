namespace Codesaurs.Models;

public class Course
{
    public Guid? Id { get; set; }
    public string? Name { get; set; }
    public string? ShortDescription { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }
    public decimal? Duration { get; set; }
    public decimal? Price { get; set; }
    public string? Language { get; set; }
    public string? Level { get; set; }
    public List<string> Stages { get; set; }
    public List<string>? Chips { get; set; }
    public string PracticeDescription { get; set; }
    public int MaxScore { get; set; }
    public int? Views { get; set; }
}