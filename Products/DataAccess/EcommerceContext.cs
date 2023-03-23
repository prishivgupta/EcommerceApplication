using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Products.Models;

namespace Products.DataAccess;

public partial class EcommerceContext : DbContext
{
    public EcommerceContext()
    {
    }

    public EcommerceContext(DbContextOptions<EcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Tcategory> Tcategories { get; set; }

    public virtual DbSet<Tproduct> Tproducts { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    { }
    //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
    //    => optionsBuilder.UseSqlServer("Data Source=IN3305444W1;Initial Catalog=Ecommerce;trusted_connection=true;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Tcategory>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK_T_Category");

            entity.ToTable("TCategory");

            entity.Property(e => e.CategoryImage)
                .HasMaxLength(500)
                .IsUnicode(false);
            entity.Property(e => e.CategoryName)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Tproduct>(entity =>
        {
            entity.HasKey(e => e.ProductId);

            entity.ToTable("TProduct");

            entity.Property(e => e.ProductDescription)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.ProductImages)
                .HasMaxLength(1000)
                .IsFixedLength();
            entity.Property(e => e.ProductName)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.Category).WithMany(p => p.Tproducts)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TProduct__Catego__4F7CD00D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
