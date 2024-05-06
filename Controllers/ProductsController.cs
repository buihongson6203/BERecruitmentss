using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BERecruitmentss.Models;
using BERecruitmentss.Repository;
using System;
using System.IO;
using System.Threading.Tasks;
using BERecruitmentss.Controllers;

namespace BE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController<Product>
    {
        public ProductsController(IBaseRepository<Product> repository) : base(repository)
        {
        }

        [HttpPost("UploadImage")]
        public async Task<IActionResult> UploadImage(IFormFile image)
        {
            try
            {
                if (image == null || image.Length == 0)
                {
                    return BadRequest("No image uploaded");
                }

                // Tạo thư mục lưu ảnh nếu chưa tồn tại
                var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images");
                if (!Directory.Exists(uploadDir))
                {
                    Directory.CreateDirectory(uploadDir);
                }

                // Tạo tên file duy nhất
                var fileName = $"{Guid.NewGuid()}_{image.FileName}";

                // Đường dẫn lưu trữ
                var filePath = Path.Combine(uploadDir, fileName);

                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    await image.CopyToAsync(fileStream);
                }

                // Trả về đường dẫn ảnh
                var imageUrl = $"{Request.Scheme}://{Request.Host}/images/{fileName}";

                return Ok(new { imageUrl });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
