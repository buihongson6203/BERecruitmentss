using BERecruitmentss.Data;
using BERecruitmentss.Models;
using Microsoft.EntityFrameworkCore;

namespace BERecruitmentss.Repository
{
    public interface IVancanciesRepository : IBaseRepository<Vacancies>
    {
        Task<Vacancies> GetByIdAsync(int id);
        Task<Vacancies> GetVacancyByRecruitmentIDAsync(int recruitmentID);
    }

    public class VancanciesRepository : BaseRepository<Vacancies>, IVancanciesRepository
    {
        public VancanciesRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }

        public async Task<Vacancies> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<Vacancies> GetVacancyByRecruitmentIDAsync(int recruitmentID)
        {
            return await _context.Vacancies
                .Include(v => v.RecruitmentApplicant)
                .FirstOrDefaultAsync(v => v.Id == recruitmentID);
        }
    }
}
