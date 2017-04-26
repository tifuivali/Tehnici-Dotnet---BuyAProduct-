﻿namespace Store.Domain.CartManagement
{
    public interface ICartRepository
    {
        int CreateCart(string email);
        Cart GetUserCart(string email);

        int UpdateUserCart(Cart cart);

        int AddProductToCart(int productId, string userEmail);
    }
}