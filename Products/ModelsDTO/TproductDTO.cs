using Products.Models;
using System.ComponentModel.DataAnnotations;

namespace Products.ModelsDTO
{
    public class TproductDTO
    {
        [Key]
        public int ProductId { get; set; }

        public string ProductName { get; set; } = null!;

        public int ProductPrice { get; set; }

        public string ProductDescription { get; set; } = null!;

        public int ProductQuantity { get; set; }

        public string? ProductImages { get; set; }

        public double? Rating { get; set; }

        public int ProductDiscountedPrice { get; set; }

        public int CategoryId { get; set; }

        public virtual Tcategory Category { get; set; } = null!;
    }
}
