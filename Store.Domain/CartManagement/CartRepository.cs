using AutoMapper;
using Store.Database;
using Store.Domain.CustomerManagement;

namespace Store.Domain.CartManagement
{
    public class CartRepository : ICartRepository
    {
        private readonly StoreContext _context;
        public CartRepository(StoreContext context)
        {
            _context = context;
        }

        public int CreateCart(Customer customer)
        {
            var cartDto = new Database.Models.Cart()
            {
                Customer = Mapper.Map<Database.Models.Customer>(customer),
                Id = 0,
                Products = null
            };

            _context.Carts.Add(cartDto);

            return cartDto.Id;
        }
    }
}
