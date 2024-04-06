using Persistence.Entities;
using QuanBichVanPS28709_ASM.Models.CartDto;

namespace QuanBichVanPS28709_ASM.MappingProfiles
{
    public class CartProfile : AutoMapper.Profile
    {
        public CartProfile()
        {
            MappingProfiles();
        }

        private void MappingProfiles()
        {
            CreateMap<Cart, CartDto>().ReverseMap();
            //CreateMap<Cart, GetCartToView>().ReverseMap();
        }
    }
}
