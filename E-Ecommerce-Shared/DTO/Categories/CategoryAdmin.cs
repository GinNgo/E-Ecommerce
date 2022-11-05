using E_Ecommerce_Shared.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace E_Ecommerce_Shared.DTO.Categories
{
    public class CategoryAdmin : AuditableDto
    {

        public int CategoryId { get; set; }
       
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public int? ParentId { get; set; }



    }
}
