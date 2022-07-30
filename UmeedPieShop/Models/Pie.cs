using System.ComponentModel.DataAnnotations;
namespace UmeedPieShop.Models
{
    public class Pie
    {
        public int PieId { get; set; }

        [Display(Name = "Pie Name")]
        public string Name { get; set; }

        [Display(Name = "Short Description")]
        public string ShortDescription { get; set; }

        [Display(Name = "Long Description")]
        public string LongDescription { get; set; }

        [Display(Name = "Price in INR")]
        public decimal Price { get; set; }
        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Take A look")]
        public string ImageThumbnailUrl { get; set; }

        [Display(Name = "Pie of the Week")]
        public bool IsPieOfTheWeek { get; set; }

        [Display(Name = "In Stock")]
        public bool InStock { get; set; }
        [Display(Name = "Category Id")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }

    }
}
