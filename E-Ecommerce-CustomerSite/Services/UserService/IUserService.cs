using E_Ecommerce_Shared.DTO.Register;
using Microsoft.AspNetCore.Mvc;

namespace E_Ecommerce_CustomerSite.Services.UserService
{
    public interface IUserService
    {
        public Task<Boolean> SignUpAsync(UserSignUp userSignUp);
    }
}
