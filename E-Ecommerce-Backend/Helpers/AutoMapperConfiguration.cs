using AutoMapper;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Shared.DTO;

namespace E_Ecommerce_Backend.Mappings
{
    public class AutoMapperConfiguration:Profile
    {
       public AutoMapperConfiguration()
        {
            CreateMap<Category, CategoriesDto>().ReverseMap();
        }
    }
}
