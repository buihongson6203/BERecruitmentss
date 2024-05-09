using BERecruitmentss.Models;
using BERecruitmentss.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;

namespace BERecruitmentss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : BaseController<Staff>
    {
        private IStaffRepository _staffRepository;
        public StaffController(IBaseRepository<Staff> repository, IStaffRepository stafflRepository) : base(repository)
        {
            _staffRepository = stafflRepository;
        }
    }
}
