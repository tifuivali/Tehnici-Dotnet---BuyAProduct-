using Store.Domain.CustomerManagement;

namespace Store.Domain.CartManagement
{
    public interface ICartRepository
    {
        int CreateCart(Customer customer);
    }
}