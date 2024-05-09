using BERecruitmentss.Models;
using BERecruitmentss.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace BERecruitmentss.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    
    public class VancanciesController : BaseController<Vacancies>
    {
        private IVancanciesRepository _vancanciesRepository;
        public VancanciesController(IBaseRepository<Vacancies> repository, IVancanciesRepository vancanciesRepository) : base(repository)
        {
            vancanciesRepository = _vancanciesRepository;
        }
    }
}
