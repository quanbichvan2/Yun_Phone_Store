using Persistence.Entities;
using QuanBichVanPS28709_ASM.Models;
using QuanBichVanPS28709_ASM.Models.ProductDto;

namespace QuanBichVanPS28709_ASM.Services
{
    public interface IProductService
    {
        // task là xử lý bất đồng bộ
        Task<Products> CreateProduct(Products products);

        Task<Products> UpdateProduct(Guid ProductId, Products products);

        Task<bool> DeleteProduct(Guid ProductId);

        Task<Products> GetProductById(Guid ProductId);

        Task<IEnumerable<GetProductsToView>> GetAllProducts(Filter? filter); // dùng IEnumerable dùng để đọc foreach

    }
}
