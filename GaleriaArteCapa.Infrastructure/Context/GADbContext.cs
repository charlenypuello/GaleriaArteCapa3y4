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

    public virtual DbSet<Artwork> Artworks { get; set; }

    public virtual DbSet<ObrasDeArte> ObrasDeArtes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artwork>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Artworks__3214EC072F94FC7C");

            entity.Property(e => e.Artist).HasMaxLength(100);
            entity.Property(e => e.ImageUrl).HasMaxLength(255);
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<ObrasDeArte>(entity =>
        {
            entity.ToTable("ObrasDeArte");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
