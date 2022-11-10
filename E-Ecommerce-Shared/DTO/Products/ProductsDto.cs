using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using E_Ecommerce_Shared.DTO.Categories;
using E_Ecommerce_Shared.DTO.Admin;

namespace E_Ecommerce_Shared.DTO.Product
{
    public class ProductsDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? DescDescription { get; set; }
        public string? FullDescription { get; set; }
        public decimal Price { get; set; }
        public decimal PriceDiscount { get; set; }
        public int Quantity { get; set; }
        public string? OriginName { get; set; }

        public List<ImagesDto>? Images { get; set; }
        public List<CategoriesDto>? Categories { get; set; }
        public string? BrandName { get; set; }
        public ICollection<RatingDto>? Rating { get; set; }

    }
}

