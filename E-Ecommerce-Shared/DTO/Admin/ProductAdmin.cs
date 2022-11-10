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

namespace E_Ecommerce_Shared.DTO.Admin
{
    public class ProductAdmin : AuditableDto
    {
        public int ProductId { get; set; }
        public string? ProductName { get; set; }
        public string? DescDescription { get; set; }
        public string? FullDescription { get; set; }
        public double? Price { get; set; }
        public double? PriceDiscount { get; set; }
        public int Quantity { get; set; }
        
        public OriginAdmin? Origin { get; set; }

        public  ICollection<CategoryAdmin>? Categories { get; set; }


        public  ICollection<ImageAdmin>? Images { get; set; }
      
        public BrandAdmin? Brand { get; set; }

        //public virtual ICollection<Rating>? Rating { get; set; }

    }
}
