﻿using Microsoft.EntityFrameworkCore;

namespace UmeedPieShop.Models
{
    public class ShoppingCart
    {
        private readonly AppDbContext _appDbContext;
        private ShoppingCart(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public string CartId { get; set; } //user specific

        public List<CartItem> CartItems { get; set; } //list of items

        public static ShoppingCart GetCart(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;

            var context = services.GetService<AppDbContext>();
            string cartId = session.GetString("CartId") ?? Guid.NewGuid().ToString();

            session.SetString("CartId", cartId);

            return new ShoppingCart(context) { CartId = cartId };
        }

        public void AddToCart(Pie pie, int amount)
        {
            // all cart items for specific user

            var AllCartItem = _appDbContext.CartItems.SingleOrDefault( s => s.Pie.PieId == pie.PieId && s.CartId == CartId);

            if (AllCartItem == null)
            {
                AllCartItem = new CartItem
                {
                    CartId = CartId,
                    Pie = pie,
                    Amount = 1
                };
                _appDbContext.CartItems.Add(AllCartItem);
            }
            else
            {
                AllCartItem.Amount++;
            }
            _appDbContext.SaveChanges();
        }

        public int RemoveFromCart(Pie pie)
        {
            var AllCartItem = _appDbContext.CartItems.SingleOrDefault(s => s.Pie.PieId == pie.PieId && s.CartId == CartId);
            var localAmount = 0;

            if (AllCartItem != null)
            {
                if (AllCartItem.Amount > 1)
                {
                    AllCartItem.Amount--;
                    localAmount = AllCartItem.Amount;
                }
                else
                {
                    _appDbContext.CartItems.Remove(AllCartItem);
                }
            }
            _appDbContext.SaveChanges();
            return localAmount;
        }

        public List<CartItem> GetCartItems()
        {
            return CartItems ?? (CartItems = _appDbContext.CartItems.Where(c => c.CartId == CartId).Include(s => s.Pie).ToList());
        }

        public void ClearCart()
        {
            var cartItems = _appDbContext.CartItems.Where(cart => cart.CartId == CartId);
            _appDbContext.CartItems.RemoveRange(cartItems);
            _appDbContext.SaveChanges();
        }

        public decimal GetCartTotal()
        {
            return _appDbContext.CartItems.Where(c => c.CartId == CartId).Select(c => c.Pie.Price * c.Amount).Sum();
        }
    }
}