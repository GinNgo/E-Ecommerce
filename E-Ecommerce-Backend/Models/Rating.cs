using E_Ecommerce_Backend.Abstract;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace E_Ecommerce_Backend.Models
{
    [Table("Rating")]
    public class Rating
    {
            [Key]
            public int RatingId { get; set; }
            [Required]
            [Range(1,5)]    
            public int Score { get; set; }
            public Product? Product { get; set; }

    }
}
