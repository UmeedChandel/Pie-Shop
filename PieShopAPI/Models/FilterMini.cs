using System.ComponentModel.DataAnnotations;

namespace PieShopAPI.Models
{
    public class FilterMini
    {
        public int PieId { get; set; }

        [Display(Name = "Pie Name")]
        public string Name { get; set; }

        [Display(Name = "Price in INR")]
        public decimal Price { get; set; }

        [Display(Name = "Take A look")]
        public string ImageThumbnailUrl { get; set; }

        [Display(Name = "Pie of the Week")]
        public bool IsPieOfTheWeek { get; set; }

        [Display(Name = "In Stock")]
        public bool InStock { get; set; }
    }
}
