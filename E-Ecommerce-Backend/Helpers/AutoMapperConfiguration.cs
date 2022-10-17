using AutoMapper;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Shared.DTO.CategoryDto;

namespace E_Ecommerce_Backend.Mappings
{
    public class AutoMapperConfiguration:Profile
    {
       public AutoMapperConfiguration()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
        }
    }
}
