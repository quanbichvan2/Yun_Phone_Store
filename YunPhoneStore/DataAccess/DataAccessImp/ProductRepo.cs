using Microsoft.EntityFrameworkCore;
using Persistence.Data;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.DataAccess.DataAccessImp;
using QuanBichVanPS28709_ASM.Models;
using QuanBichVanPS28709_ASM.Models.ProductDto;

namespace QuanBichVanPS28709_ASM.DataAccess.DataAccessImp
{
    //productRepo quản lý kho lưu trữ của product (only product), còn baseRepo là cổng (thằng nào cũng cần để đi qua)
    // mục đích làm để tránh sự phụ thuộc (mấy bài cũ phụ thuộc lặp lại cả từ bus và service)
    public class ProductRepo : BaseRepository<Product>, IProductRepo // 1 class không được đặt trước interface
    {
        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Product> CreateProduct(Product product)
        {
            return await CreateEntity(product);
        }

        public async Task<bool> DeleteProduct(Product product)
        {
            return await DeleteEntity(product);
        }

        public async Task<IEnumerable<Product>> GetAllProducts(Filter? filter)
        {
            return await _context.Products.Skip((filter.CurrentPage - 1) * filter.PageSize).Take(filter.PageSize).Include(p => p.Category).ToListAsync();
        }

        public async Task<IEnumerable<Product>> GetAllProductsByCategoryId(FilterProduct filter)
        {
            return await _context.Products.Where(p => p.CategoryId == filter.CategoryId).Skip(filter.CurrentPage - 1).Take(filter.PageSize).ToListAsync();
        }

        public async Task<Product> GetProductById(Guid ProductId)
        {
            return await _context.Products.Where(p => p.Id == ProductId).Include(c => c.Category).FirstOrDefaultAsync();
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            return await UpdateEntity(product);
        }
    }
}
