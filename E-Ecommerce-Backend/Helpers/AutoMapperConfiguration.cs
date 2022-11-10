using AutoMapper;
using E_Ecommerce_Backend.Models;
using E_Ecommerce_Shared.DTO;
using E_Ecommerce_Shared.DTO.Admin;
using E_Ecommerce_Shared.DTO.Categories;
using E_Ecommerce_Shared.DTO.Product;

namespace E_Ecommerce_Backend.Mappings
{
    public class AutoMapperConfiguration:Profile
    {
       public AutoMapperConfiguration()
        {
            CreateMap<Category, CategoriesDto>().ReverseMap();
            CreateMap<RatingDto, Rating>().ReverseMap();
            CreateMap<Rating, RatingDto>().ReverseMap();
            CreateMap<Image, ImagesDto>().ReverseMap();
            CreateMap<Product, ProductsDto>()
                .ForMember(item => item.BrandName, options => options.MapFrom(item => item.Brand!.BrandName))
                .ForMember(item => item.OriginName, options => options.MapFrom(item => item.Origin!.OriginName)) 
                 .ForMember(item => item.Rating, options => options.MapFrom(item => item.Rating))
                .ReverseMap();
            CreateMap<Product, ProductAdmin>()
              .ForMember(item => item.Categories, options => options.MapFrom(item => item.Categories))
               //.ForMember(item => item.Rating, options => options.MapFrom(item => item.Rating))
              .ReverseMap();
            CreateMap<Origin, OriginAdmin>().ReverseMap();
            CreateMap<Brand, BrandAdmin>().ReverseMap();
            CreateMap<Image, ImageAdmin>().ReverseMap();
            CreateMap<Category, CategoryAdmin>()    
                .ReverseMap();
            CreateMap<Category, CategoryParent>()
              .ForMember(item => item.value, options => options.MapFrom(item => item.CategoryId))
              .ForMember(item => item.label, options => options.MapFrom(item => item.CategoryName))
         .ReverseMap();
        }
    }
}
