using E_Ecommerce_Backend.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Ecommerce_Backend.Data
{
    public class EcommecreDbContext:DbContext
    {
        public EcommecreDbContext(DbContextOptions options) : base(options) { }

        #region DbSet
        public DbSet<Category> Categories { get; set; }
        #endregion
    }
}
