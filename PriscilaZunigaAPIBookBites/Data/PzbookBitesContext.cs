using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using PriscilaZunigaAPIBookBites.Data.Models;

namespace PriscilaZunigaAPIBookBites.Data;

public partial class PzbookBitesContext : DbContext
{
    public PzbookBitesContext()
    {
    }

    public PzbookBitesContext(DbContextOptions<PzbookBitesContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Pzcopium> Pzcopia { get; set; }

    public virtual DbSet<Pzlibro> Pzlibros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=PZBookBites;Trusted_Connection=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Pzcopium>(entity =>
        {
            entity.HasKey(e => e.PzcopiaId);

            entity.ToTable("PZCopia");

            entity.HasIndex(e => e.PzlibroId, "IX_PZCopia_PZLibroID");

            entity.Property(e => e.PzcopiaId).HasColumnName("PZCopiaID");
            entity.Property(e => e.Pzcantidad).HasColumnName("PZCantidad");
            entity.Property(e => e.Pzcolor).HasColumnName("PZColor");
            entity.Property(e => e.PzfechaCopia).HasColumnName("PZFechaCopia");
            entity.Property(e => e.Pzformato).HasColumnName("PZFormato");
            entity.Property(e => e.PzlibroId).HasColumnName("PZLibroID");

            entity.HasOne(d => d.Pzlibro).WithMany(p => p.Pzcopia).HasForeignKey(d => d.PzlibroId);
        });

        modelBuilder.Entity<Pzlibro>(entity =>
        {
            entity.ToTable("PZLibro");

            entity.Property(e => e.PzlibroId).HasColumnName("PZLibroID");
            entity.Property(e => e.Pzautor).HasColumnName("PZAutor");
            entity.Property(e => e.Pznombre).HasColumnName("PZNombre");
            entity.Property(e => e.Pzprecio).HasColumnName("PZPrecio");
            entity.Property(e => e.Pztitulo).HasColumnName("PZTitulo");
            entity.Property(e => e.Pzvolumen).HasColumnName("PZVolumen");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
