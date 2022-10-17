using E_Ecommerce_Shared.DTO.CategoryDto;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;

namespace E_Ecommerce_CustomerSite.Extensions
{
    public static class HttpClientExtensions
    {
 
        public static async Task<List<T>> GetAsJsonAsync<T>(HttpClient httpClient, string url)
        {
            var response = await httpClient.GetAsync(url);
            var contents = await response.Content.ReadAsStringAsync();
            var results = JsonConvert.DeserializeObject<List<T>>(contents);

            return results ?? new List<T>();
        }
    }
}
