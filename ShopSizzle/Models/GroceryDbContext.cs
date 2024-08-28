using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ShopSizzle.Models;

public partial class GroceryDbContext : DbContext
{
    public GroceryDbContext()
    {
    }

    public GroceryDbContext(DbContextOptions<GroceryDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AdminLogin> AdminLogins { get; set; }

    public virtual DbSet<LoginDetail> LoginDetails { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AdminLogin>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AdminLog__3214EC277731526F");

            entity.ToTable("AdminLogin");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasComputedColumnSql("('A'+right('0000'+CONVERT([varchar](4),[ID]),(4)))", true)
                .HasColumnName("UserID");
            entity.Property(e => e.UserName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<LoginDetail>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__LoginDet__3214EC2726FB4414");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.UserId)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasComputedColumnSql("('U'+right('0000'+CONVERT([varchar](4),[ID]),(4)))", true)
                .HasColumnName("UserID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
