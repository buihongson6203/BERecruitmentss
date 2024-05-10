using BERecruitmentss.Models;
using BERecruitmentss.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using RouteAttribute = Microsoft.AspNetCore.Components.RouteAttribute;
namespace BERecruitmentss.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VancanciesController : BaseController<Vacancies>
    {
        private IVancanciesRepository _vancanciesRepository;
        public VancanciesController(IBaseRepository<Vacancies> repository, IVancanciesRepository vancanciesRepository) : base(repository)
        {
            _vancanciesRepository = vancanciesRepository;
        }
    }
}
