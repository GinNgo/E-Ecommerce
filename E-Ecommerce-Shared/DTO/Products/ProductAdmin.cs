using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using E_Ecommerce_Shared.Abstract;
using E_Ecommerce_Shared.DTO.Categories;

namespace E_Ecommerce_Shared.DTO.Products
{
    public class ProductAdmin:AuditableDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? DescDescription { get; set; }
        public string? FullDescription { get; set; }
        public double? Price { get; set; }
        public double? PriceDiscount { get; set; }
        public int Quantity { get; set; }
        public string? OriginName { get; set; }
        //public Origin? Origin { get; set; }

        public virtual ICollection<CategoryAdmin>? Categories { get; set; }

        //public string? ImageUrl { get; set; }
        //public virtual ICollection<Image>? Images { get; set; }
        public string? BrandName { get; set; }
        //public Brand? Brand { get; set; }

        //public virtual ICollection<Rating>? Rating { get; set; }

    }
}
