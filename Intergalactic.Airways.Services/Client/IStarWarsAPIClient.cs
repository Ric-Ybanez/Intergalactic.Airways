using Intergalactic.Airways.Common.Model;
using Intergalactic.Airways.Common.Response;
using System.Threading.Tasks;

namespace Intergalactic.Airways.Services.Client
{
    public interface IStarWarsAPIClient
    {
        Task<StarshipResponse> GetStarships(string url);
        Task<Person> GetPerson(string url);
    }
}