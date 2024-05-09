using BERecruitmentss.Data;
using BERecruitmentss.Models;

namespace BERecruitmentss.Repository
{
    public interface IRecruitmentApplicantRepository : IBaseRepository<RecruitmentApplicant>
    {

    }
    public class RecruitmentApplicantRepository : BaseRepository<RecruitmentApplicant>
    {
        public RecruitmentApplicantRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
