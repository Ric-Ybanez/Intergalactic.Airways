using Intergalactic.Airways.Common.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Intergalactic.Airways.Services
{
    public interface IStarWarsService
    {
        Task<IEnumerable<StarshipPilotResponse>> GetStarshipByPassengersCount(int passengers);
    }
}