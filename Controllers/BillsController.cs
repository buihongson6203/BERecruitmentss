using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BERecruitmentss.Common.BillDTO;
using BERecruitmentss.Models;
using BERecruitmentss.Repository;

namespace BERecruitmentss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillsController : BaseController<Bill>
    {
        private IBillRepository _billRepository;
        public BillsController(IBaseRepository<Bill> repository, IBillRepository billRepository) : base(repository)
        {
            _billRepository = billRepository;
        }
        [HttpPost]
        [Route("InsertFullDetail")]
        public async Task<IActionResult> InsertFullDetailAsync(RequestBillFullDetail request)
        {
            try
            {
                var result = await _billRepository.InsertFullDetailAsync(request);
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Không thể xử lý yêu cầu.");
                }
            }
            catch (Exception ex)
            {
                // Ghi log về ngoại lệ để kiểm tra chi tiết hơn
                return BadRequest($"Có lỗi xảy ra: {ex.Message}");
            }
        }

        [HttpGet]
        [Route("GetAllBills")]
        public async Task<IActionResult> Test()
        {
            try
            {
                var result = await _billRepository.GetAll();
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Không thể xử lý yêu cầu.");
                }
            }
            catch (Exception ex)
            {
                // Ghi log về ngoại lệ để kiểm tra chi tiết hơn
                return BadRequest($"Có lỗi xảy ra: {ex.Message}");
            }
        }

    }
}