using E_Ecommerce_Shared.DTO.Register;
using E_Ecommerce_Shared.DTO.Users;

namespace E_Ecommerce_Backend.Services.UserService
{
    public interface IUserService
    {
        public Task<Boolean> CreateUser(UserSignUp user);
        public Task<List<UserInfo>> GetUserInfoAsync();
    }
}
