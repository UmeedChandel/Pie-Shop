using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UmeedPieShop.Models;

namespace UmeedPieShop.Controllers
{
    public class FilterController : Controller
    {
        private readonly IConfiguration _configuration;
        string baseAddress;
        public FilterController(IConfiguration configuration)
        {
            _configuration = configuration;
            baseAddress = configuration.GetValue<string>("BaseAddress");
        }


        [Authorize]
        public ViewResult FilterUp()
        {
            var pies = StaticApiData.GetApiPieData(baseAddress + "Filter/PriceAsc");
            return View(pies.Result);
        }

        [Authorize]
        public ViewResult FilterDown()
        {
            var pies = StaticApiData.GetApiPieData(baseAddress + "Filter/PriceDesc");
            return View(pies.Result);
        }

        [Authorize]
        public ViewResult FilterName()
        {
            var pies = StaticApiData.GetApiPieData(baseAddress + "Filter/ByName");
            return View(pies.Result);
        }

        [Authorize]
        public ViewResult FilterStock()
        {
            var pies = StaticApiData.GetApiPieData(baseAddress + "Filter/ByStock");
            return View(pies.Result);
        }
    }
}
