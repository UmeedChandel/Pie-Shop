using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;

namespace UmeedPieShop.Components
{
    public class ListMenu: ViewComponent // <<=== Equivalent to Controller
    {
        public ListMenu()
        {
            
        }
        public IViewComponentResult Invoke() // <<=== Equivalent to Action Method
        {
            return View();
        }
    }

    // View Component Intract With Database directly
}
