using System.Net.Http;
using System.Threading.Tasks;

namespace Intergalactic.Airways.Client
{
    public static class HttpResponseMessageExtensions
    {
        public static async Task<HttpResponseMessage> EnsureApiSuccessAsync(this HttpResponseMessage response)
        {
            try
            {
                return response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException hre)
            {
                string body = await response.Content.ReadAsStringAsync();
                throw new ApiException(body, hre.Message, hre.InnerException, hre.StatusCode);
            }
        }
    }
}