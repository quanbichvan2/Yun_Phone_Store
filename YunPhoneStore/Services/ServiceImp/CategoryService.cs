
using AutoMapper;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.DataAccess;
using QuanBichVanPS28709_ASM.Models;
using QuanBichVanPS28709_ASM.Models.CategoryDto;

namespace QuanBichVanPS28709_ASM.Services.ServiceImp
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepo _categoryRepo;
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepo categoryRepo, IMapper mapper)
        {
            _categoryRepo = categoryRepo;
            _mapper = mapper;
        }
        public async Task<Category> CreateCategory(Category category)
        {
            try
            {
                return await _categoryRepo.CreateCategory(category);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> DeleteCategory(Guid CategoryId)
        {
            try
            {
                var category = await _categoryRepo.GetCategoryById(CategoryId);
                if (category != null)
                {
                    await _categoryRepo.DeleteCategory(category);
                }
            }
            catch (Exception ex)
            {
                return false;
            }
            return true;
        }
        
        public async Task<IEnumerable<GetCategoryToView>> GetAllCategories()
        {
            try
            {
                IEnumerable<Category> category = await _categoryRepo.GetAllCategories();
                IEnumerable<GetCategoryToView> res = _mapper.Map<IEnumerable<GetCategoryToView>>(category);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public async Task<GetCategoryToView> GetCategoryById(Guid CategoryId)
        {
            try
            {
                Category category = await _categoryRepo.GetCategoryById(CategoryId);
                GetCategoryToView res = _mapper.Map<GetCategoryToView>(category);
                return res;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        //public async Task<GetCategoryToView> UpdateCategory(Guid CategoryId, CategoryUpdateDto categoryDto)
        //{
        //    try
        //    {
        //        Category category = await _categoryRepo.GetCategoryById(CategoryId);
        //        if(category != null)
        //        {
        //            Category categoryUpdate = _mapper.Map<Category>(categoryDto);
        //            Category res = await _categoryRepo.UpdateCategory(categoryUpdate);
        //            if(res != null)
        //            {
        //                GetCategoryToView categorysToView = _mapper.Map<GetCategoryToView>(res);
        //                return categorysToView;
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //    return null;
        //}
    }
}
