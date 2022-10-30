using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ecommerce_Shared.DTO
{
    public class ProductPagingDto
    {
        public int totalCount { get; set; }
        public List<ProductsDto>? products { get; set; }
    }
}
