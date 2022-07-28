using System.ComponentModel.DataAnnotations;

namespace UmeedPieShop.Models
{
    public class PieMini
    {
        [Display(Name = "Pie ID")]
        public int PieId { get; set; }

        [Display(Name = "Pie Name")]
        public string Name { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Price in INR")]
        public decimal Price { get; set; }
    }
}
