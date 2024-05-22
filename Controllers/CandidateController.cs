using BERecruitmentss.Models;
using BERecruitmentss.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace BERecruitmentss.Controllers
{
    [Microsoft.AspNetCore.Components.Route("api/[controller]")]
    [ApiController]
    public class CandidateController : BaseController<Candidate>
    {
        private ICandidateRepository _candidateRepository;

        public CandidateController(IBaseRepository<Candidate> repository, ICandidateRepository candidateRepository) : base(repository)
        {
            _candidateRepository = candidateRepository;
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
                var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Cv");
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
