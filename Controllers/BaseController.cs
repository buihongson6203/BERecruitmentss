using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BERecruitmentss.Common;
using BERecruitmentss.Models;
using BERecruitmentss.Repository;

namespace BERecruitmentss.Controllers
{
    // [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController<T> : ControllerBase where T : Base
    {
        private IBaseRepository<T> _repository;

        public BaseController(IBaseRepository<T> repository)
        {
            _repository = repository;
        }


        // [Authorize(Roles = "ADMIN,SUBADMIN,CUSTOMER")]
        [HttpGet]
        [Route("GetAll")]
        public async Task<ActionResult<List<T>>> GetAll()
        {
            //var result = await _repository.SortAndPagination(colName, isAsc, index, size);
            var result = await _repository.GetAllNoPagAndFilter();
            return Ok(result);
        }
        [HttpPost]
        // [Authorize(Roles = "ADMIN,SUBADMIN,CUSTOMER")]
        [Route("fullFilter")]
        public async Task<ActionResult<List<T>>> FullFilter([FromBody] FiterRequestDTO requestDTO)
        {
            var result = await _repository.FullFilter_1(requestDTO);
            return Ok(result);
        }


        [HttpGet("by-id/{id}")]
        // [Authorize(Roles = "ADMIN,SUBADMIN,CUSTOMER")]

        public async Task<ActionResult<T>> GetById(int id)
        {
            var result = await _repository.GetById(id);
            return Ok(result);
        }

        [HttpGet("by-email/{email}")]
        // [Authorize(Roles = "ADMIN,SUBADMIN,CUSTOMER")]

        public async Task<ActionResult<T>> GetByEmail(string email)
        {
            var result = await _repository.GetByEmail(email);
            return Ok(result);
        }

        [HttpPost]
        [Route("Create")]
        // [Authorize(Roles = "ADMIN,SUBADMIN")]

        public async Task<ActionResult<T>> Create(T entity)
        {
            var result = await _repository.Create(entity);
            return Ok(result);
        }

        [HttpPut]
        [Route("Update")]
        // [Authorize(Roles = "ADMIN,SUBADMIN")]

        public async Task<ActionResult<T>> Update(T entity)
        {
            
            var result = await _repository.Update(entity);
            return Ok(result);
        }

        [HttpDelete]
        // [Authorize(Roles = "ADMIN,SUBADMIN")]
        public async Task<ActionResult<T>> Delete(int id)
        {
            var result = await _repository.Delete(id);
            return Ok(result);
        }
    }
}
