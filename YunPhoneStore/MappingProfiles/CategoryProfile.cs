
using AutoMapper;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.Models.CategoryDto;

namespace QuanBichVanPS28709_ASM.MappingProfiles
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            MappingProfiles();
        }

        private void MappingProfiles()
        {
            CreateMap<Category, GetCategoryToView>().ReverseMap();
           // CreateMap<Category, CategoryUpdateDto>().ReverseMap();
        }
    }
}
