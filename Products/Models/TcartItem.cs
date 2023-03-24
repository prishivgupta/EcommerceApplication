using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Products.Models
{
    public class TcartItem
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("CartId")]
        public int? CartId { get; set; }

        public virtual Tcart? Cart { get; set; }

        [ForeignKey("ProductId")]
        public int? ProductId { get; set; }

        public virtual Tproduct? Product { get; set; }
        public int ProductQuantity { get; set; }

    }
}
