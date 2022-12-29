using E_Ecommerce_Shared.DTO.Admin;

namespace E_Ecommerce_Backend.Services.OriginService
{
    public interface IOriginService
    {
        public Task<List<OriginAdmin>> GetCategoriesParentAsync();
    }
}
