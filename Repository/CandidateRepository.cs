using BERecruitmentss.Data;
using BERecruitmentss.Models;

namespace BERecruitmentss.Repository
{
    public interface ICandidateRepository : IBaseRepository<Candidate>
    {


    }
    public class CandidateRepository : BaseRepository<Candidate> , ICandidateRepository
    {
        public CandidateRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
