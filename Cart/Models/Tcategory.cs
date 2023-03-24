using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Cart.Models;

public partial class Tcategory
{
    [Key]
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryImage { get; set; }
}
