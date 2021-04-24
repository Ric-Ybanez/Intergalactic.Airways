using Intergalactic.Airways.Services;
using Intergalactic.Airways.Services.Client;
using Microsoft.Extensions.DependencyInjection;
using System.Threading.Tasks;

namespace Intergalactic.Airways
{
    class Program
    {
        public static async Task Main(string[] args) =>
            await ConfigureServices(args).
                  GetService<App>()!.
                  RunAsync();

        private static ServiceProvider ConfigureServices(string[] args)
        {
            var serviceColl = new ServiceCollection();

            // APIs
            serviceColl.AddHttpClient<IStarWarsAPIClient, StarWarsAPIClient>();

            // Services
            serviceColl.AddTransient<IStarWarsService, StarWarsService>();

            // Main App
            serviceColl.AddTransient<App>();

            return serviceColl.BuildServiceProvider();
        }
    }
}
