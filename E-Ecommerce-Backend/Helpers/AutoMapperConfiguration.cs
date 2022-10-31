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
            CreateMap<Product, ProductsDto>()
                .ForMember(item => item.BrandName, options => options.MapFrom(item => item.Brand.BrandName))
                .ForMember(item => item.OriginName, options => options.MapFrom(item => item.Origin.OriginName))
                .ForMember(item => item.ImageUrl, options => options.MapFrom(item => item.ImageUrl))
                .ForMember(item => item.Categories, options => options.MapFrom(item => item.Categories)).ReverseMap();
            CreateMap<RatingDto,Rating>().ReverseMap();
        }
    }
}
