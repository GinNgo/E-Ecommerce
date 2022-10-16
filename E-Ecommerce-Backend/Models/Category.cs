using E_Ecommerce_Backend.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Ecommerce_Backend.Models
{
    [Table("Category")]
    public class Category : Auditable
    {
        [Key]
        public int CategoryId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? CategoryName { get; set; }
        public string? CategoryDescription { get; set; }
        public int CategoryLevel { get; set; }
        [Required]
        public int ParentId { get; set; }

    }
}
