namespace Pathfinder.Models;

public class Attraction
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public double Latitude { get; set; }
    public double Longitude { get; set; }
    public bool IsOutdoor { get; set; }
    
    // Scored 1 to 10. 10 means very high focus on exploration (walking, history)
    public int ExplorationScore { get; set; }
    
    // Scored 1 to 10. 10 means very high focus on relaxation (park, spa, cafe)
    public int RelaxationScore { get; set; }
    
    // Estimated time spent at the attraction in minutes
    public int RecommendedDurationMinutes { get; set; }
}
