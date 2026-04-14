using System;
using System.Linq;
using Pathfinder.Modules.Attractions.Application;
using Pathfinder.Modules.Attractions.Infrastructure;
using Pathfinder.Modules.Attractions.Domain;

namespace TerminalDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new InMemoryAttractionRepository();
            var resRepo = new InMemoryReservationRepository();
            var service = new AttractionService(repo, resRepo);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("=====================================");
                Console.WriteLine("     INTERAKTYWNE MENU ATRAKCJI      ");
                Console.WriteLine("=====================================");
                Console.WriteLine("1. Wybierz i wyświetl atrakcje na konkretną porę roku");
                Console.WriteLine("2. Pokaż atrakcje wyłącznie dla niepełnosprawnych");
                Console.WriteLine("3. Wyświetl atrakcje wraz z ich pojemnością (Max Rezerwacji)");
                Console.WriteLine("0. Wyjście");
                Console.WriteLine("=====================================");
                Console.Write("Wybierz opcję: ");
                
                var input = Console.ReadLine();

                if (input == "0") break;

                switch (input)
                {
                    case "1":
                        ShowSeasonMenu(service);
                        break;
                    case "2":
                        ShowAccessibleAttractions(service);
                        break;
                    case "3":
                        ShowCapacities(service);
                        break;
                    default:
                        Console.WriteLine("\nNieprawidłowy wybór. Naciśnij Enter, aby spróbować ponownie...");
                        Console.ReadLine();
                        break;
                }
            }
        }

        static void ShowSeasonMenu(AttractionService service)
        {
            Console.Clear();
            Console.WriteLine("--- WYBIERZ SEZON ---");
            Console.WriteLine("1. Wiosna (Spring)");
            Console.WriteLine("2. Lato (Summer)");
            Console.WriteLine("3. Jesień (Autumn)");
            Console.WriteLine("4. Zima (Winter)");
            Console.WriteLine("5. Całoroczne (YearRound)");
            Console.Write("Wybierz opcję (1-5): ");
            
            var option = Console.ReadLine();
            Season? selectedSeason = option switch
            {
                "1" => Season.Spring,
                "2" => Season.Summer,
                "3" => Season.Autumn,
                "4" => Season.Winter,
                "5" => Season.YearRound,
                _ => null
            };

            if (selectedSeason == null)
            {
                Console.WriteLine("\nNieprawidłowy wybór sezonu.");
            }
            else
            {
                var grouped = service.GetAttractionsGroupedBySeason();
                if (grouped.TryGetValue(selectedSeason.Value, out var attractions) && attractions.Any())
                {
                    Console.WriteLine($"\nZnalezione atrakcje dla sezonu: {selectedSeason.Value}");
                    foreach (var attr in attractions)
                    {
                        Console.WriteLine($" - {attr.Name} ({attr.City})");
                    }
                }
                else
                {
                    Console.WriteLine($"\nBrak skonfigurowanych atrakcji dla sezonu: {selectedSeason.Value}");
                }
            }
            
            Console.WriteLine("\nNaciśnij Enter, aby wrócić do menu...");
            Console.ReadLine();
        }

        static void ShowAccessibleAttractions(AttractionService service)
        {
            Console.WriteLine("\n--- ATRAKCJE DLA NIEPEŁNOSPRAWNYCH ---");
            var accessible = service.GetAccessibleAttractions();
            
            if (!accessible.Any())
            {
                 Console.WriteLine("Brak odpowiednich atrakcji w systemie.");
            }
            else 
            {
                foreach (var attr in accessible)
                {
                    Console.WriteLine($" - {attr.Name} (Miasto: {attr.City}, Sezon: {attr.Season})");
                }
            }
            
            Console.WriteLine("\nNaciśnij Enter, aby wrócić do menu...");
            Console.ReadLine();
        }

        static void ShowCapacities(AttractionService service)
        {
            Console.WriteLine("\n--- POJEMNOŚĆ / MAX REZERWACJI ATRAKCJI ---");
            var allAttractions = service.GetAttractionsGroupedBySeason().SelectMany(g => g.Value).ToList();
            
            // Sortujemy od najbardziej pojemnych
            foreach (var attr in allAttractions.OrderByDescending(a => a.MaxConcurrentReservations))
            {
                Console.WriteLine($" - {attr.Name} | Max Pojemność: {attr.MaxConcurrentReservations} | Miasto: {attr.City}");
            }
            
            Console.WriteLine("\nNaciśnij Enter, aby wrócić do menu...");
            Console.ReadLine();
        }
    }
}
