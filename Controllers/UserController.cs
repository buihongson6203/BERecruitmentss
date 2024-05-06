using BERecruitmentss.Models;
using BERecruitmentss.Repository;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BERecruitmentss.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseController<Users>
    {
        private IUserRepository _userRepository;
        public UserController(IBaseRepository<Users> repository, IUserRepository userlRepository) : base(repository)
        {
            _userRepository = userlRepository;
        }
    }
}
