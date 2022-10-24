using E_Ecommerce_Backend.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Ecommerce_Backend.Models
{
    [Table("Brand")]
    public class Brand:Auditable
    {
        [Key]
        public int BrandId { get; set; }
        [Required]
        [MaxLength(50)]
        public string? BrandName { get; set; }
        public virtual ICollection<Product>? Product { get; set; }

    
    }
}
