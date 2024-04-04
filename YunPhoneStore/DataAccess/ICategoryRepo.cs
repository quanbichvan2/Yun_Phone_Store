using Persistence.Entities;
using QuanBichVanPS28709_ASM.DataAccess.Base;
using QuanBichVanPS28709_ASM.Models;

namespace QuanBichVanPS28709_ASM.DataAccess
{
    public interface ICategoryRepo : IBaseRepository<Category>
    {
        Task<Category> CreateCategory(Category category);

        Task<Category> UpdateCategory(Category category);

        Task<bool> DeleteCategory(Category category);

        Task<Category> GetCategoryById(Guid CategoryId);

        Task<IEnumerable<Category>> GetAllCategories();
      
    }
}
        
