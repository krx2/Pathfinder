namespace Pathfinder.Models;

public class UserPreferences
{
    // Preferred walking distance overall in km
    public double WalkingDistanceKm { get; set; }
    
    // Modes: "Walking", "PublicTransport", "Car"
    public string TransportMode { get; set; } = "Walking";

    // 1 to 10 (1 = Only Relax, 10 = Only Explore)
    public int FocusType { get; set; }
    
    // "Sunny", "Cloudy", "Raining"
    public string Weather { get; set; } = "Sunny";
}
