using System;
using System.Collections.Generic;

namespace Products.Models;

public partial class Tproduct
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int ProductPrice { get; set; }

    public string ProductDescription { get; set; } = null!;

    public int ProductQuantity { get; set; }

    public string? ProductImages { get; set; }

    public int CategoryId { get; set; }

    public double? Rating { get; set; }

    public int ProductDiscountedPrice { get; set; }

    public virtual Tcategory Category { get; set; } = null!;
}
