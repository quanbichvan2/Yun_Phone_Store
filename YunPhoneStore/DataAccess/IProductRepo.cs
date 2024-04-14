using Persistence.Entities;
using QuanBichVanPS28709_ASM.DataAccess.Base;
using QuanBichVanPS28709_ASM.Models;
using QuanBichVanPS28709_ASM.Models.ProductDto;

namespace QuanBichVanPS28709_ASM.DataAccess
{
    public interface IProductRepo : IBaseRepository<Product>
    {
        Task<Product> CreateProduct(Product product);

        Task<Product> UpdateProduct(Product product);

        Task<bool> DeleteProduct(Product product);

        Task<Product> GetProductById(Guid ProductId);

        Task<Filter<Product>> GetAllProducts(FilterProduct filter);
        //Task<Filter<Product>> GetAllProductsByCategoryId(FilterProduct filter);
        Task<Filter<Product>> GetListPagination(IQueryable<Product> query,int page, int pageSize);
        //
    }
}
