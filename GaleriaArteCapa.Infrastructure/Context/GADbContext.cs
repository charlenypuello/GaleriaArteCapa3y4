using System;
using System.Collections.Generic;
using GaleriaArteCapa.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace GaleriaArteCapa.Infrastructure.Context;

public partial class GADbContext : DbContext
{
    public GADbContext(DbContextOptions<GADbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Interaccione> Interacciones { get; set; }

    public virtual DbSet<Obra> Obras { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Interaccione>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Interacc__3214EC078E652F28");

            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Tipo).HasMaxLength(20);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Interacciones)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Interacci__Usuar__787EE5A0");
        });

        modelBuilder.Entity<Obra>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Obras__3214EC071E468EC8");

            entity.Property(e => e.Categoria).HasMaxLength(50);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Titulo).HasMaxLength(100);
            entity.Property(e => e.UrlImagen).HasMaxLength(255);

            entity.HasOne(d => d.Usuario).WithMany(p => p.Obras)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Obras__UsuarioId__74AE54BC");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3214EC074A86E7E1");

            entity.ToTable("Usuario");

            entity.HasIndex(e => e.Usuario1, "UQ__Usuario__E3237CF7CEAA378C").IsUnique();

            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Contrasena).HasMaxLength(255);
            entity.Property(e => e.FechaRegistro)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(50);
            entity.Property(e => e.Usuario1)
                .HasMaxLength(50)
                .HasColumnName("Usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
