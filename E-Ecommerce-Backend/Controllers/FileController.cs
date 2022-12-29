using E_Ecommerce_Backend.Data;
using E_Ecommerce_Backend.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;

namespace E_Ecommerce_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly EcommecreDbContext _context;
        public FileController(EcommecreDbContext context) {
            _context = context;
                }
        [HttpPost]

        public async Task<ActionResult> Post([FromForm] FileModel fileModel)
        {
            try
            {

                var file = Request.Form.Files[0];
                var folderName = Path.Combine("wwwroot", "Upload");
                var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folderName);
                if (file.Length > 0)
                {
                    var fileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
                    var fullPath = Path.Combine(pathToSave, fileName);
                    var dbPath = Path.Combine(folderName, fileName);
                    using (var stream = new FileStream(fullPath, FileMode.Create))
                    {
                        file.CopyTo(stream);
                    }
                    var product = _context.Products.FirstOrDefault(p=>p.ProductId==fileModel.Id);

                    Image image = new Image
                    {
                        ImageUrl = fileName,
                        ImageName = fileName,
                        DisplayOrder = fileModel.DisplayOrder,
                        Product = product,
                        Status = true,
                        CreateBy = "admin",
                        CreateDate = DateTime.Now
                    };
                     _context.Images.Add(image);
                    _context.SaveChanges();
                    return Ok(new { dbPath });
                }
                else
                {
                    return BadRequest();
                }

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error:{ex}");
            }
        }
        [HttpDelete]
        public IActionResult Delete(string imgdel)
        {
            imgdel = Path.Combine("wwwroot", "Upload", imgdel);
            FileInfo fileInfo= new FileInfo(imgdel);
            if (fileInfo.Exists)
            {
                System.IO.File.Delete(imgdel);
                fileInfo.Delete();
                return Ok("Successfull");
            }
            return BadRequest("Deleted is fail");
        }
        
    }
}
