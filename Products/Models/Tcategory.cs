using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Products.Models;

public partial class Tcategory
{
    [Key]
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;

    public string? CategoryImage { get; set; }
}
