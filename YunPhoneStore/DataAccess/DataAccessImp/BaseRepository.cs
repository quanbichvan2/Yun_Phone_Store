using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using QuanBichVanPS28709_ASM.DataAccess.Base;
using QuanBichVanPS28709_ASM.Models;

namespace QuanBichVanPS28709_ASM.DataAccess.DataAccessImp
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        private readonly ApplicationDbContext _context;
        protected DbSet<TEntity> set;
        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            set = context.Set<TEntity>();
        }
        public async Task<TEntity> CreateEntity(TEntity entity)
        {
            _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteEntity(TEntity entity)
        {
            _context.Remove(entity);
            await _context.SaveChangesAsync();
            return true;
        }

        //public async Task<IEnumerable<TEntity>> GetAllEntities(Filter? filter)
        //{
        //    return null;
        //}

        //public Task<IEnumerable<TEntity>> GetAllEntities(Models.Filter filter)
        //{
        //    throw new NotImplementedException();
        //}

        public async Task<TEntity> GetEntityById(Guid id)
        {
            // return await _context.FindFindAsync(id);
            return null;
        }

        public Task<Filter<TEntity>> GetListPagination(IQueryable<TEntity> query, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        public async Task<TEntity> UpdateEntity(TEntity entity)
        {
            _context.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
