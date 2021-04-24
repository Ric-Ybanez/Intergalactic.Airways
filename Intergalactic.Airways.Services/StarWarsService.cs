using Intergalactic.Airways.Common.Model;
using Intergalactic.Airways.Common.Response;
using Intergalactic.Airways.Services.Client;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace Intergalactic.Airways.Services
{
    public class StarWarsService : IStarWarsService
    {
        private readonly IStarWarsAPIClient _api;
        public StarWarsService(IStarWarsAPIClient api) => _api = api;

        public async Task<IEnumerable<StarshipPilotResponse>> GetStarshipsByAllowedPassengersCount(int passengers)
        {
            var starShips = (await GetAllStarships())
                                    .Where(i => int.TryParse(i.Passengers, NumberStyles.AllowThousands, CultureInfo.CurrentCulture.NumberFormat, out int maxPassengers) && maxPassengers >= passengers)
                                        .ToList();

            if (!starShips.Any())
                return null;

            var populatePilotTasks = starShips.Select(PopulatePilotListTask);
            var starshipWithPilots = await Task.WhenAll(populatePilotTasks);

            return starshipWithPilots.Select(s => new StarshipPilotResponse
            {
                PilotsName = s.PilotList.Select(s => s.Name).ToArray(),
                StarshipName = s.Name
            });
        }

        private async Task<List<Starship>> GetAllStarships()
        {
            string nextUrl = string.Empty;
            var response = await _api.GetStarships(nextUrl);
            var starShips = response.Results;
            nextUrl = response.Next;

            while (!string.IsNullOrEmpty(nextUrl))
            {
                var resp = await _api.GetStarships(nextUrl);
                nextUrl = resp.Next;
                starShips.AddRange(resp.Results);
            }

            return starShips;
        }

        private async Task<Starship> PopulatePilotListTask(Starship starship)
        {
            var getPersonTasks = starship.Pilots.Select(GetPerson);
            starship.PilotList = (await Task.WhenAll(getPersonTasks)).ToList();
            return starship;
        }

        private async Task<Person> GetPerson(string pilotUrl)
        {
            return await _api.GetPerson(pilotUrl);
        }
    }
}
