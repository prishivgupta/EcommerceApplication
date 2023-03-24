using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cart.Models
{
    public class Torder
    {
        [Key]
        public int OrderId { get; set; }

        [ForeignKey("UserId")]
        public int? UserId { get; set; }

        public virtual Tuser? User { get; set; }

        [ForeignKey("CartId")]
        public int? CartId { get; set; }

        public virtual Tcart? Cart { get; set; }

        public string ShipmentAddress { get; set; }

        public string OrderStatus { get; set; }

        public DateTime DateOfPurchase { get; set; }
    }
}
