using System;
using System.Collections.Generic;

namespace Products.Models;

public partial class Tcategory
{
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryImage { get; set; }

    public virtual ICollection<Tproduct> Tproducts { get; } = new List<Tproduct>();
}
