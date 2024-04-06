using Persistence.Entities;
using QuanBichVanPS28709_ASM.Models;
using QuanBichVanPS28709_ASM.Models.ProductDto;

namespace QuanBichVanPS28709_ASM.Services
{
    public interface IProductService
    {
        // task là xử lý bất đồng bộ
        Task<Product> CreateProduct(ProductCreateDto productDto);

        Task<GetProductsToView> UpdateProduct(Guid ProductId, ProductUpdateDto productDto);

        Task<bool> DeleteProduct(Guid ProductId);

        Task<GetProductsToView> GetProductById(Guid ProductId);

        Task<IEnumerable<GetProductsToView>> GetAllProducts(Filter? filter); // dùng IEnumerable dùng để đọc foreach
                                                                             // phần xử lý là laptop hay phone
        Task<IEnumerable<GetProductsToView>> GetAllProductsByCategoryId(FilterProduct filter);
    }
}