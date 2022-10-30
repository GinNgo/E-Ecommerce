using E_Ecommerce_Shared.DTO;

namespace E_Ecommerce_CustomerSite.Models
{
    public class ProductViewModel
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public int totalCount { get; set; }
        public List<ProductsDto>? productsDtos { get; set; }

    }
}
