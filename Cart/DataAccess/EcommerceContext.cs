using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Cart.Models;

namespace Cart.DataAccess;

public partial class EcommerceContext : DbContext
{
    public EcommerceContext(DbContextOptions<EcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tcategory> Tcategories { get; set; }

    public virtual DbSet<Tproduct> Tproducts { get; set; }

    public virtual DbSet<Tuser> Tusers { get; set; }

    public virtual DbSet<Tcart> Tcarts { get; set; }

    public virtual DbSet<TcartItem> TcartItems { get; set; }

    public virtual DbSet<Torder> Torders { get; set; }
}
