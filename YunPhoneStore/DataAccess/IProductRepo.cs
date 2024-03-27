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

        Task<IEnumerable<Product>> GetAllProducts(Filter? filter);
        Task<IEnumerable<Product>> GetAllProductsByCategoryId(FilterProduct filter);
        //
    }
}
