
using AutoMapper;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.DataAccess;
using QuanBichVanPS28709_ASM.Models;
using QuanBichVanPS28709_ASM.Models.ProductDto;

namespace QuanBichVanPS28709_ASM.Services.ServiceImp
{
    public class ProductService : IProductService
    {
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;
        public ProductService(IProductRepo productRepo, IMapper mapper)
        {
            _productRepo = productRepo;
            _mapper = mapper;
        }
        public async Task<Product> CreateProduct(Product product)
        {
            try
            {
                return await _productRepo.CreateProduct(product);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteProduct(Guid ProductId)
        {
            try
            {
                var product = await _productRepo.GetProductById(ProductId);
                if (product != null)
                {
                    await _productRepo.DeleteProduct(product);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }

        public async Task<IEnumerable<GetProductsToView>> GetAllProducts(Filter? filter) // filter dùng để phân trang
        {
            try
            {
                IEnumerable<Product> product = await _productRepo.GetAllProducts(filter);
                IEnumerable<GetProductsToView> res = _mapper.Map<IEnumerable<GetProductsToView>>(product);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<IEnumerable<GetProductsToView>> GetAllProductsByCategoryId(FilterProduct filter)
        {
            try
            {
                IEnumerable<Product> product = await _productRepo.GetAllProductsByCategoryId(filter);
                IEnumerable<GetProductsToView> res = _mapper.Map<IEnumerable<GetProductsToView>>(product);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<GetProductsToView> GetProductById(Guid ProductId)
        {
            try
            {
                Product product = await _productRepo.GetProductById(ProductId);
                GetProductsToView res = _mapper.Map<GetProductsToView>(product);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Product> UpdateProduct(Guid ProductId, Product product)
        {
            try
            {
                return await _productRepo.UpdateProduct(product);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
