using E_Ecommerce_Backend.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Ecommerce_Backend.Models
{
    [Table("Product")]
    public class Product: Auditable
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? ProductName { get; set; }
        public string? DescDescription { get; set; }
        public string? FullDescription { get; set; }

        [Range(0,double.MaxValue)]
        public double? Price { get; set; }
     
        [Range(0,double.MaxValue)]
        public double? PriceDiscount { get; set; }
   
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }
    
        [MaxLength(100)]
        public string? Origin { get; set; }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category? Category { get; set; }
       

    }
}
