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
        [Range(1, 5)]
        public int Score { get; set; }
        public string? Comment { get; set; }
        public string? Email { get; set; }
        public string ?Name { get; set; }
        public Product? Product { get; set; }

        public User user { get; set; }
        public DateTime CreateDate { get; set; }

    }
}

