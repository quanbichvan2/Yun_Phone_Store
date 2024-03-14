//using DataAccess.DataAccess.Base;
//using Microsoft.EntityFrameworkCore;
//using Persistence;
//using QuanBichVanPS28709_ASM.Models;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Xml;

//namespace DataAccess.DataAccess.DataAccessImp
//{
//    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity>where TEntity : class
//    {
//        private readonly ApplicationDbContext _context;
//        protected DbSet<TEntity> set;
//        public BaseRepository(ApplicationDbContext context) 
//        {
//            _context = context;
//            set = context.Set<TEntity>();
//        }
//        public async Task<TEntity> CreateEntity(TEntity entity)
//        {
//            _context.AddAsync(entity);
//            await _context.SaveChangesAsync();
//            return entity;
//        }

//        public async Task<bool> DeleteEntity(TEntity entity)
//        {
//            _context.Remove(entity);
//            await _context.SaveChangesAsync();
//            return true;
//        }

//        public async Task<IEnumerable<TEntity>> GetAllEntities(Filter filter)
//        {
//            return null;
//        }

//        public async Task<TEntity> GetEntityById(Guid id)
//        {
//           // return await _context.FindAsync(id);
//            return null;
//        }

//        public async Task<TEntity> UpdateEntity(TEntity entity)
//        {
//            _context.Update(entity);
//            await _context.SaveChangesAsync();
//            return entity;
//        }
//    }
//}
