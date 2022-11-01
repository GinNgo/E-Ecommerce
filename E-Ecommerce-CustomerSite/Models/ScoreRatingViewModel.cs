using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ecommerce_CustomerSite.Models
{
    public class ScoreRatingViewModel
    {
        public int total { get; set; } = 0;
        public int countTotal { get; set; } = 0;
        public int one { get; set; } = 0;
        public int two { get; set; } = 0;
        public int three { get; set; } = 0;
        public int four { get; set; } = 0;
        public int five { get; set; } = 0;
    }
}
