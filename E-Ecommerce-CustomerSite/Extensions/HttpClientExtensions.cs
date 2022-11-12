using E_Ecommerce_Shared.DTO;
using Newtonsoft.Json;
using System.Security.Cryptography.X509Certificates;
using System.Text;

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

        public static async Task<T?> PostAsJsonAsync<Param, T>(this HttpClient httpClient, string url, Param param)
        {
            var objParam = JsonConvert.SerializeObject(param);
            var response = await httpClient.PostAsync(url, new StringContent(objParam, Encoding.UTF8, "application/json"));
            var content = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<T>(content);

            return result;
        }
    



    }
}
