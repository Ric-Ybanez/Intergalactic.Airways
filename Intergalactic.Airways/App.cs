using Intergalactic.Airways.Services;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Intergalactic.Airways
{
    public class App
    {
        private readonly IStarWarsService _service;
        public App(IStarWarsService service)
        {
            _service = service;
        }

        public async Task RunAsync()
        {
            Console.WriteLine("Please input number of passengers: ");
            string passengerStr = Console.ReadLine();

            if (!int.TryParse(passengerStr, NumberStyles.AllowThousands, CultureInfo.CurrentCulture.NumberFormat, out int passengers))
            {
                Console.WriteLine("Invalid number of passengers");
                ExitApplication();
                return;
            }

            Console.WriteLine("Processing....");
            var starships = await _service.GetStarshipByPassengersCount(passengers);

            if (starships == null) 
            {
                Console.WriteLine($"No starship found that can carry {passengers} passengers");
                ExitApplication();
                return;
            }
                
            foreach (var starship in starships)
            {
                var pilotsName = starship.PilotsName.Any() ? String.Join(",", starship.PilotsName) : "No Pilot";
                Console.WriteLine($"{starship.StarshipName} - {pilotsName}");
            }
            
            ExitApplication();
        }

        private void ExitApplication() 
        {
            Console.WriteLine("Press any key to exit application..");
            Console.ReadLine();
        }
    }
}
