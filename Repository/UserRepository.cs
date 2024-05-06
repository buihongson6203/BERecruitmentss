using BERecruitmentss.Common.BillDTO;
using BERecruitmentss.Data;
using BERecruitmentss.Models;

namespace BERecruitmentss.Repository
{
    public interface IUserRepository : IBaseRepository<Users>
    {

 
    }
    public class UserRepository : BaseRepository<Users>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor) : base(context, httpContextAccessor)
        {
        }



    }
}
