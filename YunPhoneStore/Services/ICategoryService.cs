using Persistence.Entities;
using QuanBichVanPS28709_ASM.Models;
using QuanBichVanPS28709_ASM.Models.CategoryDto;

namespace QuanBichVanPS28709_ASM.Services
{
    public interface ICategoryService
    {
        // task là xử lý bất đồng bộ
        Task<Category> CreateCategory(Category category);

        //Task<GetCategoryToView> UpdateCategory(Guid CategoryId, CategoryUpdateDto categoryDto);

        Task<bool> DeleteCategory(Guid CategoryId);

        Task<GetCategoryToView> GetCategoryById(Guid CategoryId);

        Task<IEnumerable<GetCategoryToView>> GetAllCategories(); // dùng IEnumerable dùng để đọc foreach
                                                                             // phần xử lý là laptop hay phone
    }
}