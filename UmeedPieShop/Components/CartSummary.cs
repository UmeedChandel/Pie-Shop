using UmeedPieShop.Models;
using UmeedPieShop.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace UmeedPieShop.Components
{
    public class CartSummary : ViewComponent
    {
        private readonly ShoppingCart _shoppingCart;

        public CartSummary(ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
        }

        public IViewComponentResult Invoke()
        {
            var items = _shoppingCart.GetCartItems();
            _shoppingCart.CartItems = items;

            var shoppingCartViewModel = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
                ShoppingCartTotal = _shoppingCart.GetCartTotal()
            };
            return View(shoppingCartViewModel);
        }
    }
}