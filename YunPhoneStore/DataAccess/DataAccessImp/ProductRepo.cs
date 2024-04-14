using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Persistence.Data;
using Persistence.Entities;
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

        public async Task<Filter<Product>> GetAllProducts(FilterProduct filter)
        {

            var demo = await GetListPagination(_context.Products
                    .Where(p => (filter.ProductName.IsNullOrEmpty() || p.Name.Contains(filter.ProductName)) &&
                   (filter.CategoryId == null || p.CategoryId == filter.CategoryId)
                    )
                    .Include(p => p.Category)
                    , filter.page, filter.pageSize);
            return demo;
        }
        //public async Task<Filter<Product>> GetAllProductsByCategoryId(FilterProduct filter)
        //{
        //    return await GetListPagination(_context.Products.Where(p => p.CategoryId == filter.CategoryId)/*.Skip(filter.CurrentPage - 1).Take(filter.PageSize)*/.Include(p => p.Category), filter.page, filter.pageSize);
        //}

        public async Task<Filter<Product>> GetListPagination(IQueryable<Product> query, int page, int pageSize)
        {
            var totalItem = (query).Count();
            //_context.Products
            query = query.Skip((page - 1) * pageSize)
                      .Take(pageSize);
            var result = await query.ToListAsync();

            var pagination = new Filter<Product>()
            {
                Data = result,
                pageInfo = new PageInfo()
                {
                    CurrentPage = page,
                    PageSize = pageSize,
                    TotalItem = totalItem
                }
            };
            return pagination;
        }

        public async Task<Product> GetProductById(Guid ProductId)
        {
            return await _context.Products.Where(p => p.Id == ProductId).Include(c => c.Category).FirstOrDefaultAsync();
        }



        public async Task<Product> UpdateProduct(Product product)
        {
            try
            {
                return await UpdateEntity(product);
            }
            catch (Exception ex)
            {

            }
            return null;
        }
    }
}
