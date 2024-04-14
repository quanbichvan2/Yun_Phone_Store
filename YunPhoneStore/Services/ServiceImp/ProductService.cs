
using AutoMapper;
using Azure;
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
        public async Task<Product> CreateProduct(ProductCreateDto productDto)
        {
            try
            {
                Product product = _mapper.Map<Product>(productDto);
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

        public async Task<Filter<GetProductsToView>> GetAllProducts(FilterProduct filter) // filter dùng để phân trang
        {
            try
            {
                Filter<Product> products = await _productRepo.GetAllProducts(filter);

                var res = new Filter<GetProductsToView>
                {
                    Data = _mapper.Map<List<GetProductsToView>>(products.Data),
                    pageInfo = products.pageInfo // Copy PageInfo từ Filter<Product> sang Filter<GetProductsToView>
                };

                return res;
            }
            catch (Exception ex)
            {
                return new()
                {
                    Data = []
                };
            }
        }



        //public async Task<Filter<GetProductsToView>> GetAllProductsByCategoryId(FilterProduct filter)
        //{
        //    try
        //    {

        //        Filter<Product> products = await _productRepo.GetAllProducts(filter);
               
        //        var res = new Filter<GetProductsToView>
        //        {
        //            Data = _mapper.Map<List<GetProductsToView>>(products.Data),
        //            pageInfo = products.pageInfo // Copy PageInfo từ Filter<Product> sang Filter<GetProductsToView>
        //        };
        //        return res;
        //    }
        //    catch (Exception ex)
        //    {
        //        return new()
        //        {
        //            Data = []
        //        };
        //    }
        //}

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

        public async Task<GetProductsToView> UpdateProduct(Guid ProductId, ProductUpdateDto productDto)
        {
            try
            {
                Product product = await _productRepo.GetProductById(ProductId);
                if (product != null)
                {
                    //product = _mapper.Map<Product>(productDto);
                    product.Name = productDto.Name;
                    product.CategoryId = productDto.CategoryId;
                    product.Color = productDto.Color;
                    product.Memory = productDto.Memory;
                    product.Description = productDto.Description;
                    product.Price = productDto.Price;
                    product.Image = productDto.Image;
                    Product res = await _productRepo.UpdateProduct(product);
                    if (res != null)
                    {
                        GetProductsToView productsToView = _mapper.Map<GetProductsToView>(res);
                        return productsToView;
                    }
                }
            }
            catch (Exception ex)
            {
                return null;
            }
            return null;
        }
    }
}
