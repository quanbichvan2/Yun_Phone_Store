using QuanBichVanPS28709_ASM.Models;

namespace QuanBichVanPS28709_ASM.DataAccess.Base
{
    public interface IBaseRepository<TEntity>
    {
        Task<TEntity> CreateEntity(TEntity entity);

        Task<TEntity> UpdateEntity(TEntity entity);

        Task<bool> DeleteEntity(TEntity entity);

        Task<TEntity> GetEntityById(Guid id);

        Task<IEnumerable<TEntity>> GetAllEntities(Filter filter);
    }
}
