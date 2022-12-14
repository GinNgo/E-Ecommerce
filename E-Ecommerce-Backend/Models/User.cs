using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_Ecommerce_Backend.Models
{
    [Table("User")]
    public class User
    {
        public enum Roles
        {
            Admin,
            Customer,
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string? FullName { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Address { get; set; }
        public string? Password { get; set; }
        public string? Username { get; set; }
        public Roles Role { get; set; }
    }
    public class Jwt
    {
        public string? key { get; set;}
        public string? Issuer { get; set;}
        public string? Audience { get; set; }
        public string? Subject { get; set; }
    }
}
