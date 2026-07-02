using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ECommLibrary.Models;

public partial class EcommerceContext : DbContext
{
    public EcommerceContext()
    {
    }

    public EcommerceContext(DbContextOptions<EcommerceContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=.\\sqlexpress;initial catalog=ecommerce;integrated security=true;trustservercertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //Seedhe property ke upr likhne ki bajae yaha pr attributes add kro. 
        modelBuilder.Entity<Item>(e =>
        {
            e.Property<string>("ItemName").HasColumnName("varchar(40)");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.ItemId).HasName("PK__items__56A128AA28904BC8");

            entity.ToTable("items");

            entity.Property(e => e.ItemId).HasColumnName("itemId");
            entity.Property(e => e.ItemName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("itemName");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.QtyinStock).HasColumnName("qtyinStock");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__orders__0809335D8BF44AE0");

            entity.ToTable("orders");

            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("customerName");
            entity.Property(e => e.GrossAmount).HasColumnName("grossAmount");
            entity.Property(e => e.Orderdate)
                .HasColumnType("datetime")
                .HasColumnName("orderdate");
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__orderIte__3213E83FE30F75A1");

            entity.ToTable("orderItems");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ItemId).HasColumnName("itemId");
            entity.Property(e => e.OrderId).HasColumnName("orderId");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Qty).HasColumnName("qty");
            entity.Property(e => e.Value).HasColumnName("value");

            entity.HasOne(d => d.Item).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ItemId)
                .HasConstraintName("FK__orderItem__itemI__656C112C");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__orderItem__order__6477ECF3");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
