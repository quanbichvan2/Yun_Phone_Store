

using Persistence.Entities;
using QuanBichVanPS28709_ASM.DataAccess.Base;
using QuanBichVanPS28709_ASM.Models;

namespace QuanBichVanPS28709_ASM.DataAccess
{
    public interface IProductRepo : IBaseRepository<Products>
    {
        Task<Products> CreateProduct(Products products);

        Task<Products> UpdateProduct(Products products);

        Task<bool> DeleteProduct(Products products);

        Task<Products> GetProductById(Guid ProductId);

        Task<IEnumerable<Products>> GetAllProducts(Filter? filter);
    }
}
