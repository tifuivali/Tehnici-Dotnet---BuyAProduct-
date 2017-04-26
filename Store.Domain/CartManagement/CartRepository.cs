using System.Data.Entity.Migrations;
using System.Linq;
using AutoMapper;
using Store.Database;
using Store.Domain.CustomerManagement;

namespace Store.Domain.CartManagement
{
    public class CartRepository : ICartRepository
    {
        private readonly StoreContext context;
        public CartRepository(StoreContext context)
        {
            this.context = context;
        }

        public int CreateCart(string email)
        {
            var cartDto = new Database.Models.Cart()
            {
                Customer = context.Customers.SingleOrDefault(x => x.Email == email),
                Id = 0,
                Products = null
            };

            context.Carts.Add(cartDto);
            context.SaveChanges();

            return cartDto.Id;
        }

        public Cart GetUserCart(string email)
        {
            var cartDto = context.Carts.SingleOrDefault(x => x.Customer.Email == email);
            return cartDto != null ? Mapper.Map<Cart>(cartDto) : null;
        }

        public int UpdateUserCart(Cart cart)
        {
            var cartDao = Mapper.Map<Database.Models.Cart>(cart);
            context.Carts.AddOrUpdate(cartDao);
            context.SaveChanges();
            return cartDao.Id;
        }
    }
}
