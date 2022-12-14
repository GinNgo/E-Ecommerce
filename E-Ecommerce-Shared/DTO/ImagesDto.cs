using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Ecommerce_Shared.DTO.Product;

namespace E_Ecommerce_Shared.DTO
{
    public class ImagesDto
    {
        public int ImageId { get; set; }
        public string? ImageName { get; set; }
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public int? DisplayOrder { get; set; }
    }
}
