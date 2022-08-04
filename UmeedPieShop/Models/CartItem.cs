using System.ComponentModel.DataAnnotations;

namespace UmeedPieShop.Models
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }
        public Pie Pie { get; set; }
        public int Amount { get; set; }
        public string CartId { get; set; } //user specific
    }
}