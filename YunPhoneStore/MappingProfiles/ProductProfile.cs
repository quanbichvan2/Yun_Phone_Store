
using AutoMapper;
using Persistence.Entities;
using QuanBichVanPS28709_ASM.Models.ProductDto;

namespace QuanBichVanPS28709_ASM.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() 
        {
            MappingProfiles();
        }

        private void MappingProfiles()
        {
            CreateMap<Products, GetProductsToView>();
        }
    }
}
