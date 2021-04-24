using Intergalactic.Airways.Client;
using Intergalactic.Airways.Common.Model;
using Intergalactic.Airways.Common.Response;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Intergalactic.Airways.Services.Client
{
    public class StarWarsAPIClient : AbstractApiClient, IStarWarsAPIClient
    {
        private const string SWAPI_BASE_URL = "https://swapi.dev/api/";
        public StarWarsAPIClient(HttpClient? client) : base(client)
        {
            _client.BaseAddress = new Uri(SWAPI_BASE_URL);
        }
        public async Task<StarshipResponse> GetStarships(string pageUrl)
        {
            return await GetAsync<StarshipResponse>(string.IsNullOrEmpty(pageUrl) ? $"starships/?page={pageUrl}" : pageUrl);
        }

        public async Task<Person> GetPerson(string url)
        {
            return await GetAsync<Person>(url);
        }
    }
}
