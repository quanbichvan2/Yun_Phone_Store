

using Persistence;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.DataAccess.DataAccessImp;
using QuanBichVanPS28709_ASM.Models;

namespace QuanBichVanPS28709_ASM.DataAccess.RepositoryImp
{
    //productRepo quản lý kho lưu trữ của product (only product), còn baseRepo là cổng (thằng nào cũng cần để đi qua)
    // mục đích làm để tránh sự phụ thuộc (mấy bài cũ phụ thuộc lặp lại cả từ bus và service)
    public class ProductRepo : BaseRepository<Products>, IProductRepo // 1 class không được đặt trước interface
    {
        private readonly ApplicationDbContext _context;
        public ProductRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Products> CreateProduct(Products products)
        {
            return await CreateEntity(products);
        }

        public async Task<bool> DeleteProduct(Products products)
        {
            return await DeleteEntity(products);
        }

        public async Task<IEnumerable<Products>> GetAllProducts(Filter filter)
        {
            return await GetAllEntities(filter);
        }

        public async Task<Products> GetProductById(Guid ProductId)
        {
            return await GetEntityById(ProductId);
        }

        public async Task<Products> UpdateProduct(Products products)
        {
            return await UpdateEntity(products);
        }
    }
}
