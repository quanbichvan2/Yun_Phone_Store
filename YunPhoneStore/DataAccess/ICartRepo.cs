using Persistence.Entities;
using QuanBichVanPS28709_ASM.DataAccess.Base;

namespace QuanBichVanPS28709_ASM.DataAccess
{
    public interface ICartRepo : IBaseRepository<Cart>
    {
        Task<Cart> Checkout(Cart cart);
        //Task<Cart> GetCartByCartId(Guid id);
        //update later , chức năng check log giao dịch khách hàng của admin
        //Task<IEnumerable<Cart>> GetAllCarts(Filter? filter);
    }
}
