
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
        public async Task<Products> CreateProduct(Products products)
        {
            try
            {
                return await _productRepo.CreateProduct(products);
            }catch (Exception ex)
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
                IEnumerable<Products> products = await _productRepo.GetAllProducts(filter);
                IEnumerable<GetProductsToView> res = _mapper.Map<IEnumerable<GetProductsToView>>(products);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Products> GetProductById(Guid ProductId)
        {
            try
            {
                return await _productRepo.GetProductById(ProductId);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<Products> UpdateProduct(Guid ProductId, Products products)
        {
            try
            {
                return await _productRepo.UpdateProduct(products);
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
