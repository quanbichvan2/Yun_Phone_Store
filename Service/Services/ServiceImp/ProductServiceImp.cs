//using DataAccess.DataAccess;
//using Persistence.Entities;

//namespace Service.Services.ServiceImp
//{
//    public class ProductServiceImp : IProductService
//    {
//        private readonly IProductRepo _productRepo;
//        public ProductServiceImp(IProductRepo productRepo) 
//        {
//            _productRepo = productRepo;
//        }
//        public async Task<Products> CreateProduct(Products products)
//        {
//            try
//            {
//                return await _productRepo.CreateProduct(products);
//            }catch (Exception ex)
//            {
//                return null;
//            }
//        }

//        public async Task<bool> DeleteProduct(Guid ProductId)
//        {
//            try
//            {
//                var product = await _productRepo.GetProductById(ProductId);
//                if (product != null)
//                {
//                    await _productRepo.DeleteProduct(product);
//                }
//            }
//            catch (Exception ex)
//            {
//                return false;
//            }
//            return true;
//        }

//        public async Task<IEnumerable<Products>> GetAllProducts(Filter filter)
//        {
//            try
//            {
//                return await _productRepo.GetAllProducts(filter);
//            }
//            catch (Exception ex)
//            {
//                return null;
//            }
//        }

//        public async Task<Products> GetProductById(Guid ProductId)
//        {
//            try
//            {
//                return await _productRepo.GetProductById(ProductId);
//            }
//            catch (Exception ex)
//            {
//                return null;
//            }
//        }

//        public async Task<Products> UpdateProduct(Guid ProductId, Products products)
//        {
//            try
//            {
//                return await _productRepo.UpdateProduct(products);
//            }
//            catch (Exception ex)
//            {
//                return null;
//            }
//        }
//    }
//}
