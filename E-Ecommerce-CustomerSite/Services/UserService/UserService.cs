using E_Ecommerce_CustomerSite.Service;
using E_Ecommerce_Shared.DTO.Product;
using E_Ecommerce_Shared.DTO;
using E_Ecommerce_Shared.DTO.Register;
using Microsoft.AspNetCore.Mvc;
using E_Ecommerce_CustomerSite.Extensions;
using E_Ecommerce_Shared.DTO.Users;

namespace E_Ecommerce_CustomerSite.Services.UserService
{
    public class UserService : BaseService, IUserService
    {
        public UserService(IHttpClientFactory clientFactory, IHttpContextAccessor httpContextAccessor) : base(clientFactory, httpContextAccessor)
        {
        }

        public async Task<String> LoginAsync(UserDto userDto)
        {
            var user = await httpClient.PostAsTokenAsync<UserDto>("Auth/", userDto);


            return user;
        }

        public async Task<bool> SignUpAsync(UserSignUp userSignUp)
        {
            var user = await httpClient.PostAsJsonAsync<UserSignUp, bool>("User/", userSignUp);
           

            return user;
        }
        public async Task<string> GetUserNameAsync()
        {
            var username = await httpClient.GetAsstringAsync("User/UserName");


            return username;
        }
    }
}
