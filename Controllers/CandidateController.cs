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
    private  ICandidateRepository _candidateRepository;

        public CandidateController(IBaseRepository<Candidate> repository, ICandidateRepository candidateRepository) : base(repository)
        {
            _candidateRepository = candidateRepository;
        }
    }
}
