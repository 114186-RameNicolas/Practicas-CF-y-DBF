﻿// <auto-generated />
using System;
using API_CodeFirst_Empleado.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace API_CodeFirst_Empleado.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20230803210709_segundaMigracion")]
    partial class segundaMigracion
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.9")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("API_CodeFirst_Empleado.Models.Cargo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Cargo");
                });

            modelBuilder.Entity("API_CodeFirst_Empleado.Models.Ciudad", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Ciudad");
                });

            modelBuilder.Entity("API_CodeFirst_Empleado.Models.Empleado", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Apellido")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("CargoId")
                        .HasColumnType("uuid");

                    b.Property<Guid?>("CiudadId")
                        .HasColumnType("uuid");

                    b.Property<string>("DNI")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<DateTime>("FechaAlta")
                        .HasColumnType("timestamp with time zone");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("SucursalId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("CargoId");

                    b.HasIndex("CiudadId");

                    b.HasIndex("SucursalId");

                    b.ToTable("Empleado");
                });

            modelBuilder.Entity("API_CodeFirst_Empleado.Models.Sucursal", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("CiudadId")
                        .HasColumnType("uuid");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("CiudadId");

                    b.ToTable("Sucursal");
                });

            modelBuilder.Entity("API_CodeFirst_Empleado.Models.Empleado", b =>
                {
                    b.HasOne("API_CodeFirst_Empleado.Models.Cargo", "Cargo")
                        .WithMany("Empleados")
                        .HasForeignKey("CargoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("API_CodeFirst_Empleado.Models.Ciudad", null)
                        .WithMany("Empleados")
                        .HasForeignKey("CiudadId");

                    b.HasOne("API_CodeFirst_Empleado.Models.Sucursal", "Sucursal")
                        .WithMany("Empleados")
                        .HasForeignKey("SucursalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cargo");

                    b.Navigation("Sucursal");
                });

            modelBuilder.Entity("API_CodeFirst_Empleado.Models.Sucursal", b =>
                {
                    b.HasOne("API_CodeFirst_Empleado.Models.Ciudad", "Ciudad")
                        .WithMany()
                        .HasForeignKey("CiudadId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Ciudad");
                });

            modelBuilder.Entity("API_CodeFirst_Empleado.Models.Cargo", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("API_CodeFirst_Empleado.Models.Ciudad", b =>
                {
                    b.Navigation("Empleados");
                });

            modelBuilder.Entity("API_CodeFirst_Empleado.Models.Sucursal", b =>
                {
                    b.Navigation("Empleados");
                });
#pragma warning restore 612, 618
        }
    }
}
