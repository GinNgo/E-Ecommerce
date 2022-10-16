namespace E_Ecommerce_CustomerSite.Service
{
    public class BaseService
    {
        protected readonly HttpClient httpClient;
        public BaseService(IHttpClientFactory clientFactory)
        {
            httpClient = clientFactory.CreateClient();
        }
    }
}
