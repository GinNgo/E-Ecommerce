using AutoMapper;
using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Shared.DTO.Product;
using E_Ecommerce_Shared.DTO.Register;
using E_Ecommerce_Shared.DTO.Users;
using Microsoft.EntityFrameworkCore;

namespace E_Ecommerce_Backend.Services.UserService
{
    public class UserService:IUserService
    {
        private readonly EcommecreDbContext _context;
        private readonly IMapper _mapper;
        public UserService(EcommecreDbContext context,IMapper mapper) {
            _mapper= mapper;
            _context = context;
                }
        public async Task<Boolean> CreateUser(UserSignUp userSignUp)
        {
            User user = new User();
            var userData = await _context.Users.Where(u=>u.Username!.Equals(userSignUp.UserName)).FirstOrDefaultAsync();
            if (userData == null) { return false; }
            else { 
            try
            {
                user.Email = userSignUp.Email;
                user.FullName = userSignUp.FullName;
                user.Role = User.Roles.Customer;
                user.Phone = userSignUp.Phone;
                user.Password = userSignUp.Password;
                user.Username = userSignUp.UserName;
                _context.Users.Add(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            }
        }
        public async Task<List<UserInfo>> GetUserInfoAsync()
        {
            var userData = await _context.Users.Where(c=>c.Role==User.Roles.Customer).ToListAsync();
            List<UserInfo> userInfo = _mapper.Map<List<User>, List<UserInfo>>(userData);
            return userInfo;

        }
    }
}
