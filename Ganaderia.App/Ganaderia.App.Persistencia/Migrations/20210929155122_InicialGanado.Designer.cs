﻿// <auto-generated />
using Ganaderia.App.Persistencia;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Ganaderia.App.Persistencia.Migrations
{
    [DbContext(typeof(AppContext))]
    [Migration("20210929155122_InicialGanado")]
    partial class InicialGanado
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("Ganaderia.App.Dominio.AplicacionVacuna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Fecha")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idEjemplar")
                        .HasColumnType("int");

                    b.Property<int>("idGanadero")
                        .HasColumnType("int");

                    b.Property<int>("idVacuna")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("AplicacionVacunas");
                });

            modelBuilder.Entity("Ganaderia.App.Dominio.Ganado", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("cantidad")
                        .HasColumnType("int");

                    b.Property<string>("fechaIngreso")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("idGanadero")
                        .HasColumnType("int");

                    b.Property<string>("raza")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Ganado");
                });

            modelBuilder.Entity("Ganaderia.App.Dominio.Persona", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<string>("Apellido")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Direccion")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumeroTelefono")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("contrasena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("correo")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Personas");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Persona");
                });

            modelBuilder.Entity("Ganaderia.App.Dominio.Vacuna", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .UseIdentityColumn();

                    b.Property<int>("Existencia")
                        .HasColumnType("int");

                    b.Property<string>("FechaCompra")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FechaVencimiento")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Lote")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nombre")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Vacunas");
                });

            modelBuilder.Entity("Ganaderia.App.Dominio.Ganadero", b =>
                {
                    b.HasBaseType("Ganaderia.App.Dominio.Persona");

                    b.Property<float>("Latitude")
                        .HasColumnType("real");

                    b.Property<float>("Longitude")
                        .HasColumnType("real");

                    b.HasDiscriminator().HasValue("Ganadero");
                });

            modelBuilder.Entity("Ganaderia.App.Dominio.Veterinario", b =>
                {
                    b.HasBaseType("Ganaderia.App.Dominio.Persona");

                    b.Property<float>("Latitude")
                        .HasColumnType("real")
                        .HasColumnName("Veterinario_Latitude");

                    b.Property<float>("Longitude")
                        .HasColumnType("real")
                        .HasColumnName("Veterinario_Longitude");

                    b.Property<string>("Registro")
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Veterinario");
                });
#pragma warning restore 612, 618
        }
    }
}
