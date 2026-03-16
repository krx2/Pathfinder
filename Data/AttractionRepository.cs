using System.Collections.Generic;
using Pathfinder.Models;

namespace Pathfinder.Data;

public interface IAttractionRepository
{
    List<Attraction> GetAllAttractions();
}

public class AttractionRepository : IAttractionRepository
{
    public List<Attraction> GetAllAttractions()
    {
        return new List<Attraction>
        {
            new Attraction { Id = 1, Name = "Zamek Królewski w Warszawie", Latitude = 52.2482, Longitude = 21.0144, IsOutdoor = true, ExplorationScore = 10, RelaxationScore = 2, RecommendedDurationMinutes = 120 },
            new Attraction { Id = 2, Name = "Łazienki Królewskie", Latitude = 52.2150, Longitude = 21.0354, IsOutdoor = true, ExplorationScore = 6, RelaxationScore = 10, RecommendedDurationMinutes = 150 },
            new Attraction { Id = 3, Name = "Muzeum Powstania Warszawskiego", Latitude = 52.2323, Longitude = 20.9808, IsOutdoor = false, ExplorationScore = 10, RelaxationScore = 1, RecommendedDurationMinutes = 180 },
            new Attraction { Id = 4, Name = "Centrum Nauki Kopernik", Latitude = 52.2418, Longitude = 21.0286, IsOutdoor = false, ExplorationScore = 8, RelaxationScore = 6, RecommendedDurationMinutes = 200 },
            new Attraction { Id = 5, Name = "Pałac Kultury i Nauki", Latitude = 52.2318, Longitude = 21.0060, IsOutdoor = false, ExplorationScore = 9, RelaxationScore = 4, RecommendedDurationMinutes = 90 },
            new Attraction { Id = 6, Name = "Ogród Botaniczny UW", Latitude = 52.2173, Longitude = 21.0253, IsOutdoor = true, ExplorationScore = 4, RelaxationScore = 10, RecommendedDurationMinutes = 60 },
            new Attraction { Id = 7, Name = "Muzeum Narodowe w Warszawie", Latitude = 52.2320, Longitude = 21.0249, IsOutdoor = false, ExplorationScore = 10, RelaxationScore = 3, RecommendedDurationMinutes = 150 },
            new Attraction { Id = 8, Name = "Bulwary Wiślane", Latitude = 52.2435, Longitude = 21.0298, IsOutdoor = true, ExplorationScore = 3, RelaxationScore = 10, RecommendedDurationMinutes = 120 },
            new Attraction { Id = 9, Name = "Hala Koszyki", Latitude = 52.2227, Longitude = 21.0101, IsOutdoor = false, ExplorationScore = 2, RelaxationScore = 9, RecommendedDurationMinutes = 60 },
            new Attraction { Id = 10, Name = "Stare Miasto - Rynek", Latitude = 52.2497, Longitude = 21.0122, IsOutdoor = true, ExplorationScore = 9, RelaxationScore = 5, RecommendedDurationMinutes = 60 }
        };
    }
}
