using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ecommerce_Shared.DTO.Categories
{
    public class CategoryPaging
    {
        public int totalCount { get; set; }
        public List<CategoryAdmin>? categoriesAdmin { get; set; }
    }
}
