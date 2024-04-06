using Persistence.Data;
using Persistence.Entities;

namespace QuanBichVanPS28709_ASM.DataAccess.DataAccessImp
{
    //cartRepo quản lý kho lưu trữ của cart (only cart), còn baseRepo là cổng (thằng nào cũng cần để đi qua)
    // mục đích làm để tránh sự phụ thuộc (mấy bài cũ phụ thuộc lặp lại cả từ bus và service)
    public class CartRepo : BaseRepository<Cart>, ICartRepo // 1 class không được đặt trước interface
    {
        private readonly ApplicationDbContext _context;
        public CartRepo(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Cart> Checkout(Cart cart)
        {
            return await CreateEntity(cart);
        }
    }
}
