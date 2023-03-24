using System.ComponentModel.DataAnnotations;

namespace Products.Models
{
    public class Tcart
    {
        [Key]
        public int CartId { get; set; }

        public int Discount { get; set; }

        public int TotalCost { get; set; }
    }
}
