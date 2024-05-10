using BERecruitmentss.Data;
using BERecruitmentss.Models;

namespace BERecruitmentss.Repository
{
    public interface IVancanciesRepository : IBaseRepository<Vacancies>
    {

    }

    public class VancanciesRepository : BaseRepository<Vacancies>, IVancanciesRepository
    {
        public VancanciesRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }
    }
}
