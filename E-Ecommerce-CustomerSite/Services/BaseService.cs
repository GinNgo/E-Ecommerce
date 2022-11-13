using System.Net.Http.Headers;

namespace E_Ecommerce_CustomerSite.Service
{
    public class BaseService
    {
        protected readonly HttpClient httpClient;
        
        public BaseService(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor)
        {
            httpClient = clientFactory.CreateClient();

            var token = httpContextAccessor.HttpContext?.Session.GetString("JWToken");

            if (!string.IsNullOrEmpty(token))
            {
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
            }
        }
    }
}
