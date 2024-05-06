using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BERecruitmentss.Models;
using BERecruitmentss.Repository;
namespace BERecruitmentss.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BillDetailsController : BaseController<BillDetail>
    {
        public BillDetailsController(IBaseRepository<BillDetail> repository) : base(repository)
        {
        }
    }
}