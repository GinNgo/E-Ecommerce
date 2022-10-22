using E_Ecommerce_Backend.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Ecommerce_Backend.Models
{
    [Table("Origin")]
    public class Origin:Auditable
    {
        [Key]
        public int OriginId { get; set; }
        [Required]
        [MaxLength(50)]
        public string? OriginName { get; set; }
        public Product? Product { get; set; }
    }
}
