using E_Ecommerce_Shared.DTO.Admin;
using E_Ecommerce_Shared.DTO.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ecommerce_Shared.DTO.Products
{
    public class ProductCreate
    {
        public string? ProductName { get; set; }
        public string? DescDescription { get; set; }
        public string? FullDescription { get; set; }
        public double? Price { get; set; }
        public double? PriceDiscount { get; set; }
        public int Quantity { get; set; }

        public int OriginId { get; set; }

        public ICollection<CategoryParent>? Categories { get; set; }
        public int BrandId { get; set; }

    }
}
