using BERecruitmentss.Models;
using BERecruitmentss.Repository;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace BERecruitmentss.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("api/[controller]")]
    [ApiController]
    public class RecruitmentApplicantController : BaseController<RecruitmentApplicant>
    {
        private IRecruitmentApplicantRepository _recruitmentApplicantRepository;
        public RecruitmentApplicantController(IBaseRepository<RecruitmentApplicant> repository, IRecruitmentApplicantRepository recruitmentApplicantRepository) : base(repository)
        {
            _recruitmentApplicantRepository = recruitmentApplicantRepository;
        }
    }
}
