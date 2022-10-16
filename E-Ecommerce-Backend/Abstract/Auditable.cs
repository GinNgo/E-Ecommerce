using System.ComponentModel.DataAnnotations;

namespace E_Ecommerce_Backend.Abstract
{
    public abstract class Auditable
    {
        public DateTime? CreateDate { get; set; }

        [MaxLength(256)]
        public string? CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        [MaxLength(256)]
        public string? UpdateBy { get; set; }
        public bool Status { get; set; }
        public bool IsDeleted { get; set; }
   

    }
}
