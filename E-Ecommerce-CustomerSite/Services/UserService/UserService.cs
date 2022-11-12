using E_Ecommerce_CustomerSite.Service;
using E_Ecommerce_Shared.DTO.Product;
using E_Ecommerce_Shared.DTO;
using E_Ecommerce_Shared.DTO.Register;
using Microsoft.AspNetCore.Mvc;
using E_Ecommerce_CustomerSite.Extensions;

namespace E_Ecommerce_CustomerSite.Services.UserService
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IHttpClientFactory clientFactory) : base(clientFactory) { }
        public async Task<Boolean> SignUpAsync(UserSignUp userSignUp)
        {
            var user = await httpClient.PostAsJsonAsync<UserSignUp, Boolean>("User/", userSignUp);
           

            return user;
        }
    }
}
