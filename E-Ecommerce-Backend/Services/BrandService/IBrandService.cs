using E_Ecommerce_Shared.DTO.Admin;

namespace E_Ecommerce_Backend.Services.BrandService
{
    public interface IBrandService
    {
        public Task<List<BrandAdmin>> GetCategoriesParentAsync();
    }
}
