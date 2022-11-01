using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ecommerce_Shared.DTO
{
  
        public class RatingDto
        {
            public int RatingId { get; set; }
            public int Score { get; set; }
            public string? Comment { get; set; }
            public string? Email { get; set; }
            public string ?Name { get; set; }

            public int ProductId { get; set; }
            public DateTime CreateDate { get; set; }
    }

}
