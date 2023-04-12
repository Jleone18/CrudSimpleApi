using System;
using System.Collections.Generic;
using BackEndApiSimple.Models;
using Microsoft.EntityFrameworkCore;

namespace BackEndApiSimple.Data;

public partial class ClaseProductoContext : DbContext
{
    public ClaseProductoContext()
    {
    }

    public ClaseProductoContext(DbContextOptions<ClaseProductoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ID");

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("DESCRIPCION");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_ID_PROD");

            entity.ToTable("PRODUCTO");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.IdCateg).HasColumnName("ID_CATEG");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("NOMBRE");

            entity.HasOne(d => d.IdCategNavigation).WithMany(p => p.Productos)
                .HasForeignKey(d => d.IdCateg)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_ID_CATEG");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
