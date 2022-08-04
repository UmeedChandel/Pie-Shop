using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;
using UmeedPieShop.ViewModel;

namespace UmeedPieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly IConfiguration _configuration;
        private readonly ShoppingCart _shoppingCart;
        string baseAddress;

        public ShoppingCartController(ShoppingCart shoppingCart, IConfiguration configuration, IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
            _shoppingCart = shoppingCart;
            _configuration = configuration;
            baseAddress = configuration.GetValue<string>("BaseAddress");
            
        }

        private IEnumerable<Pie> GetAllPies()
        {
            var pies = _pieRepository.AllPies;
            //StaticApiData.GetApiPieData(baseAddress + "Pie/AllPiesList");
            return pies;
                //.Result;
        }

        public ViewResult Cart()
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

        public RedirectToActionResult AddToShoppingCart(int pieId)
        {
            var selectedPie = GetAllPies().FirstOrDefault(p => p.PieId == pieId);

            if (selectedPie != null)
            {
                _shoppingCart.AddToCart(selectedPie, 1);
            }
            return RedirectToAction("Cart");
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            var selectedPie = GetAllPies().FirstOrDefault(p => p.PieId == pieId);

            if (selectedPie != null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
            }
            return RedirectToAction("Cart");
        }

        public RedirectToActionResult Clear()
        {
            _shoppingCart.ClearCart();
            return RedirectToAction("List", "Pie", new { area = "" });
        }
    
    }
}
