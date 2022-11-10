using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Shared.DTO.Register;

namespace E_Ecommerce_Backend.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly EcommecreDbContext _context;
        public UserService(EcommecreDbContext context) {
            _context = context;
                }
        public async Task CreateUser(UserSignUp userSignUp)
        {
            User user = new User();
            try
            {
                user.Email = userSignUp.Email;
                user.FullName = userSignUp.FullName;
       
                user.Password = userSignUp.Password;
                user.Username = userSignUp.UserName;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
