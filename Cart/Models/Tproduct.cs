using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cart.Models;

public partial class Tproduct
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

    [ForeignKey("CategoryId")]
    public int? CategoryId { get; set; }

    public virtual Tcategory? Category { get; set; }
}
