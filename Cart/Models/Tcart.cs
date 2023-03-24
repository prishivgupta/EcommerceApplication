using System.ComponentModel.DataAnnotations;

namespace Cart.Models
{
    public class Tcart
    {
        [Key]
        public int CartId { get; set; }

        public int Discount { get; set; }

        public int TotalCost { get; set; }
    }
}
