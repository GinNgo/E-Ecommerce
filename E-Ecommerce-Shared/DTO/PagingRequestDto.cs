using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Ecommerce_Shared.DTO
{
    public class PagingRequestDto
    {
        public int pageIndex { get; set; }
        public int pageSize { get; set; }
        public string? Search { get; set; }
        public int sort { get; set; }
        public int id { get; set; }
    }
}
