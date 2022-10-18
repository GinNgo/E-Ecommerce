using E_Ecommerce_Backend.Models;
using Microsoft.EntityFrameworkCore;
using E_Ecommerce_Shared.DTO.ProductDto;

namespace E_Ecommerce_Backend.Data
{
    public class EcommecreDbContext:DbContext
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public EcommecreDbContext(DbContextOptions options) : base(options) { }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        #region DbSet
        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<E_Ecommerce_Shared.DTO.ProductDto.ProductsDto> ProductsDto { get; set; }
        #endregion
    }
}
