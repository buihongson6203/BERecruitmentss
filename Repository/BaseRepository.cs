using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BERecruitmentss.Common;
using BERecruitmentss.Data;
using BERecruitmentss.Models;
using System.CodeDom;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Security.Claims;
using System.Text;
using Z.EntityFramework.Plus;

namespace BERecruitmentss.Repository
{
    public interface IBaseRepository<T> where T : Base
    {
        Task<List<T>> GetAll(int index = 1, int size = 1);
        Task<List<T>> GetAllNoPagAndFilter();
        Task<T> GetById(int id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(int id);
        Task<List<T>> SortAndPagination(string colName = "Id", bool isAsc = true, int index = 1, int size = 3);
        Task<List<T>> FullFilter_1(FiterRequestDTO requestDTO);
    }
    public class BaseRepository<T> : IBaseRepository<T> where T : Base
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> _dbSet;
        protected readonly IHttpContextAccessor _httpContextAccessor;
        public BaseRepository(ApplicationDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _dbSet = _context.Set<T>();

        }

        private string GetCurrentUserId()
        {
            return "";
        }

        public async Task<T> Create(T entity)
        {
            if (entity != null)
            {
                entity.StartedDate = DateTime.Now;
                entity.StartedBy = GetCurrentUserId();
                entity.EndedDate = DateTime.Now;
                _dbSet.Add(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }
        public async Task<T> Delete(int id)
        {
            var result = await _dbSet.FindAsync(id);
            if (result != null)
            {
                result.IsDeleted = true;
                result.DeletedAt = DateTime.Now;
                result.DeletedBy = GetCurrentUserId();

                _dbSet.Update(result);

                await _context.SaveChangesAsync();
                return result;
            }
            return null;
        }

        public async Task<List<T>> GetAll(int index = 1, int size = 1)
        {
            var result = _dbSet.AsQueryable();
            result = result.Skip((index - 1) * size).Take(size);
            return await result.ToListAsync();
        }

        public async Task<List<T>> GetAllNoPagAndFilter()
        {
            var result = await _dbSet.ToListAsync();
            return result;
        }

        public async Task<T> GetById(int id)
        {
            var result = await _dbSet.FindAsync(id);
            return result;
        }

        public async Task<T> Update(T entity)
        {
            if (entity != null)
            {
                entity.UpdatedAt = DateTime.Now;
                entity.UpdatedBy = GetCurrentUserId();

                _dbSet.Update(entity);
                await _context.SaveChangesAsync();
                return entity;
            }
            return null;
        }

        public async Task<List<T>> SortAndPagination(string colName = "Id", bool isAsc = true, int index = 1, int size = 3)
        {
            var result = _dbSet.AsQueryable();

            //Sap xep           

            if (isAsc == true)
            {
                result = result.OrderByDynamic(r => "r." + colName);
            }
            else
            {
                result = result.OrderByDescendingDynamic(r => "r." + colName);
            }

            //Phan trang
            result = result.Skip((index - 1) * size).Take(size);
            return await result.ToListAsync();
        }

        public async Task<List<T>> FullFilter_1(FiterRequestDTO requestDTO)
        {
            if (requestDTO.filterParams == null || requestDTO.filterParams.Count <= 0)
            {
                return await GetAll(requestDTO.index, requestDTO.size);
            }
            else
            {

                var result = _dbSet.AsQueryable();

                var properties = typeof(T).GetProperties();

                foreach (var property in properties)
                {
                    foreach (var item in requestDTO.filterParams)
                    {
                        if (property.Name.ToLower().Equals(item.colName.ToLower()))
                        {
                            if (property.PropertyType == typeof(string))
                            {
                                if (item._operator == "like")
                                {
                                    result = result.Where(x => EF.Property<string>(x, property.Name).Contains(item.value));
                                }
                                else if (item._operator == "equal")
                                {
                                    result = result.Where(x => EF.Property<string>(x, property.Name) == item.value);
                                }
                                else if (item._operator == "not")
                                {
                                    result = result.Where(x => !EF.Property<string>(x, property.Name).Contains(item.value));
                                }
                            }
                            else if (property.PropertyType == typeof(int))
                            {
                                if (item._operator == "equal")
                                {
                                    result = result.Where(x => EF.Property<int>(x, property.Name) == int.Parse(item.value));
                                }
                                else if (item._operator == "not")
                                {
                                    result = result.Where(x => EF.Property<int>(x, property.Name) != int.Parse(item.value));
                                }
                            }
                        }

                    }

                }
                //Sap xep
                if (requestDTO.sortAsc == true)
                {
                    result = result.OrderByDynamic(r => "r." + requestDTO.sortCol);
                }
                else
                {
                    result = result.OrderByDescendingDynamic(r => "r." + requestDTO.sortCol);
                }
                // Phân trang
                result = result.Skip((requestDTO.index - 1) * requestDTO.size).Take(requestDTO.size);

                return await result.ToListAsync();
            }


        }
    }
}
