using E_Ecommerce_Shared.DTO.Register;
using E_Ecommerce_Shared.DTO.Users;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Services.UserService
{
    public interface IUserService
    {
        public Task<bool> SignUpAsync(UserSignUp userSignUp);
        public Task<string> LoginAsync(UserDto user);

        public Task<string> GetUserNameAsync();
    }
}
