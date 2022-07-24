using System.ComponentModel.DataAnnotations;
namespace UmeedPieShop.Models
{
    public class Pie // <<== Child
    {
        public int PieId { get; set; }

        [Display(Name = "Pie Name")]
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string LongDescription { get; set; }

        [Display(Name = "Price in INR")]
        public decimal Price { get; set; }
        public string ImageUrl { get; set; }

        [Display(Name = "Take A look")]
        public string ImageThumbnailUrl { get; set; }

        [Display(Name = "Pie of the Week")]
        public bool IsPieOfTheWeek { get; set; }

        [Display(Name = "In Stock")]
        public bool InStock { get; set; }
        public int CategoryId { get; set; } // <<== Parent ID
        public Category Category { get; set; }

    }
}
