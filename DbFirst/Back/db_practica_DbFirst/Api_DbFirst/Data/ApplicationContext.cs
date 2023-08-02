using System;
using System.Collections.Generic;
using Api_DbFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace Api_DbFirst.Data;

public partial class ApplicationContext : DbContext
{
    public ApplicationContext()
    {
    }

    public ApplicationContext(DbContextOptions<ApplicationContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cargo> Cargos { get; set; }

    public virtual DbSet<Ciudade> Ciudades { get; set; }

    public virtual DbSet<Empleado> Empleados { get; set; }

    public virtual DbSet<Sucursale> Sucursales { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Name=Conexion");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasPostgresExtension("uuid-ossp");

        modelBuilder.Entity<Cargo>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Ciudade>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("pk_Ciudad");

            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.HasKey(e => e.IdCargo).HasName("pk_Empleados");

            entity.Property(e => e.IdCargo).ValueGeneratedNever();
            entity.Property(e => e.Apellido).HasMaxLength(50);
            entity.Property(e => e.Dni).HasColumnName("DNI");
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.IdCargoNavigation).WithOne(p => p.Empleado)
                .HasForeignKey<Empleado>(d => d.IdCargo)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Cargo_Empleado");
        });

        modelBuilder.Entity<Sucursale>(entity =>
        {
            entity.HasKey(e => e.IdCiudad).HasName("pk_Sucursales");

            entity.Property(e => e.IdCiudad).ValueGeneratedNever();
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.IdCiudadNavigation).WithOne(p => p.Sucursale)
                .HasForeignKey<Sucursale>(d => d.IdCiudad)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Sucursales_Ciudad");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
