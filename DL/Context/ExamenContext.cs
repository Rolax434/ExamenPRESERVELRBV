using System;
using System.Collections.Generic;
using DL.Models;
using Microsoft.EntityFrameworkCore;

namespace DL.Context;

public partial class ExamenContext : DbContext
{
    public ExamenContext()
    {
    }

    public ExamenContext(DbContextOptions<ExamenContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Articulo> Articulos { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ClienteArticulo> ClienteArticulos { get; set; }

    public virtual DbSet<TiendaArticulo> TiendaArticulos { get; set; }

    public virtual DbSet<Tiendum> Tienda { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=.;Database=ExamenPRESERVELRBV;User Id=sa;Password=pass@word1;trustservercertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Articulo>(entity =>
        {
            entity.HasKey(e => e.IdArticulo).HasName("PK__Articulo__F8FF5D521A90C41E");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PK__Clientes__D5946642A0CB50EC");
        });

        modelBuilder.Entity<ClienteArticulo>(entity =>
        {
            entity.HasKey(e => e.IdCompra).HasName("PK__ClienteA__0A5CDB5CBE767DE5");

            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.ClienteArticulos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClienteAr__IdArt__1ED998B2");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.ClienteArticulos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__ClienteAr__IdCli__1DE57479");
        });

        modelBuilder.Entity<TiendaArticulo>(entity =>
        {
            entity.HasKey(e => new { e.IdTienda, e.IdArticulo }).HasName("PK__TiendaAr__65914CBEBCCB2A7A");

            entity.Property(e => e.Fecha).HasDefaultValueSql("(getdate())");

            entity.HasOne(d => d.IdArticuloNavigation).WithMany(p => p.TiendaArticulos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TiendaArt__IdArt__1920BF5C");

            entity.HasOne(d => d.IdTiendaNavigation).WithMany(p => p.TiendaArticulos)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__TiendaArt__IdTie__182C9B23");
        });

        modelBuilder.Entity<Tiendum>(entity =>
        {
            entity.HasKey(e => e.IdTienda).HasName("PK__Tienda__5A1EB96B48860C0D");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
