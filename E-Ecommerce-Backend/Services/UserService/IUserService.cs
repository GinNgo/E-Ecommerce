using E_Ecommerce_Shared.DTO.Register;

namespace E_Ecommerce_Backend.Services.UserService
{
    public interface IUserService
    {
        public Task CreateUser(UserSignUp user);
    }
}
