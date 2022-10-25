using E_Ecommerce_Shared.DTO;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace E_Ecommerce_CustomerSite.Extensions
{
    public static class HttpClientExtensions
    {
 
        public static async Task<T?> GetAsJsonAsync<T>(this HttpClient httpClient, string url)
        {
            var response = await httpClient.GetAsync(url);
            var contents = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<T>(contents);

            return results;
        }

        public static async Task<T?> GetAsJsonOneProAsync<T>(this HttpClient httpClient, string url)
        {
            var response = await httpClient.GetAsync(url);
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(content);

            return result;
        }
    }
}
