namespace E_Ecommerce_Backend.Models
{
    public class FileModel
    {
        public int Id { get; set; }

        public int DisplayOrder { get; set; }
        public IFormFile? FormFiles { get; set; }
    }
}
