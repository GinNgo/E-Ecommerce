using E_Ecommerce_Backend.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Ecommerce_Backend.Models
{
    [Table("Image")]
    public class Image:Auditable
    {
        [Key]
        public int ImageId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? ImageName { get; set; }
        [Required]
        [MaxLength(100)]
        public string? ImageUrl { get; set; }
        public string? Title { get; set; }
        public int? DisplayOrder { get; set; }
        public Product? Product { get; set; }
    }
}
