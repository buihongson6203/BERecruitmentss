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
        [HttpPost("CreateUploadCV")]
        public async Task<IActionResult> CreateCandidate([FromForm] Candidate candidate, IFormFile cv)
        {
            try
            {
                if (candidate == null)
                {
                    return BadRequest("Candidate object is null");
                }

                // Xử lý tệp tin CV
                if (cv != null && cv.Length > 0)
                {
                    var uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Cv");
                    if (!Directory.Exists(uploadDir))
                    {
                        Directory.CreateDirectory(uploadDir);
                    }

                    var fileName = $"{Guid.NewGuid()}_{cv.FileName}";
                    var filePath = Path.Combine(uploadDir, fileName);

                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await cv.CopyToAsync(fileStream);
                    }

                    candidate.Cv = $"{Request.Scheme}://{Request.Host}/Cv/{fileName}";
                }

                // Tạo mã ứng viên duy nhất
                candidate.CandidateCode = await _candidateRepository.GenerateUniqueCodeAsync();
                candidate.DateCreated = DateTime.Now;

                _candidateRepository.Add(candidate);
                await _candidateRepository.SaveChangesAsync();

                return CreatedAtAction(nameof(CreateCandidate), new { id = candidate.Id }, candidate);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
    }
}
