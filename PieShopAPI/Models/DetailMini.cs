using System.ComponentModel.DataAnnotations;

namespace PieShopAPI.Models
{
    public class DetailMini
    {
        public int PieId { get; set; }

        [Display(Name = "Pie Name")]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        [Display(Name = "Price in INR")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
