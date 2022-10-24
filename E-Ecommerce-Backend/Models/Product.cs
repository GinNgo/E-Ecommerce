using E_Ecommerce_Backend.Abstract;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Ecommerce_Backend.Models
{
    [Table("Product")]
    public class Product : Auditable
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        [MaxLength(100)]
        public string? ProductName { get; set; }
        public string? DescDescription { get; set; }
        public string? FullDescription { get; set; }

        [Range(0, double.MaxValue)]
        public double? Price { get; set; }

        [Range(0, double.MaxValue)]
        public double? PriceDiscount { get; set; }

        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }

      
        [ForeignKey("OriginId")]
        public int OriginId { get; set; }
        public Origin? Origin { get; set; }
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public virtual ICollection<Category>? Categories { get; set; }

        public string? ImageUrl { get; set; }
        public virtual ICollection<Image>? Images { get; set; }
        [ForeignKey("BrandId")]
        public int BrandId { get; set; }
        public Brand? Brand { get; set; }
        
        public virtual ICollection<Rating>? Rating { get; set; }

    }
}
