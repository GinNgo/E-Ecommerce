using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ecommerce_Shared.DTO
{
    public class CategoriesDto
    {
        public int CategoryId { get; set; }
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public int CategoryLevel { get; set; }
        public int? ParentId { get; set; }
        public List<CategoriesDto>? Child { get; set; }
        
    }
}
