using UmeedPieShop.Models;

namespace UmeedPieShop.ViewModel
{
    public class CustomeClass
    {
        public IEnumerable<Pie> Pies { get; set; }
        public string CurrentCategory { get; set; }
        public string CategoryDescription { get; set; }


    }
}
