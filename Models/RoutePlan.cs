using System.Collections.Generic;

namespace Pathfinder.Models;

public class RoutePlan
{
    public List<Attraction> Attractions { get; set; } = new List<Attraction>();
    
    // Total distance of the route in km
    public double TotalDistanceKm { get; set; }
    
    // Total estimated time in minutes (travel + duration at attractions)
    public int TotalEstimatedTimeMinutes { get; set; }
}
