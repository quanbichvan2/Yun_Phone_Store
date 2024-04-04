using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Entities;

namespace QuanBichVanPS28709_ASM.DataAccess.DataAccessImp
{
    //categoryRepo quản lý kho lưu trữ của category (only category), còn baseRepo là cổng (thằng nào cũng cần để đi qua)
    // mục đích làm để tránh sự phụ thuộc (mấy bài cũ phụ thuộc lặp lại cả từ bus và service)
    public class CategoryRepo : BaseRepository<Category>, ICategoryRepo // 1 class không được đặt trước interface
    {
        private readonly ApplicationDbContext _context;
        public CategoryRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Category> CreateCategory(Category category)
        {
            return await CreateEntity(category);
        }

        public async Task<bool> DeleteCategory(Category category)
        {
            return await DeleteEntity(category);
        }

        public async Task<IEnumerable<Category>> GetAllCategories()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> GetCategoryById(Guid CategoryId)
        {
            return await _context.Categories.Where(p => p.Id == CategoryId).FirstOrDefaultAsync();
        }

        public async Task<Category> UpdateCategory(Category category)
        {
            return await UpdateEntity(category);
        }
    }
}
