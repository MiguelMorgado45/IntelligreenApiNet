﻿// <auto-generated />
using System;
using Intelligreen.Aplicacion;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Intelligreen.Api.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.0");

            modelBuilder.Entity("Intelligreen.Dominio.Dispositivo", b =>
                {
                    b.Property<Guid>("DispositivoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CircuitoId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("DispositivoId");

                    b.ToTable("Dispositivos");
                });

            modelBuilder.Entity("Intelligreen.Dominio.Planta", b =>
                {
                    b.Property<Guid>("PlantaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Cuidados")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Dificultad")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImgUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<double>("MaxHumedadAmb")
                        .HasColumnType("REAL");

                    b.Property<double>("MaxHumedadSuelo")
                        .HasColumnType("REAL");

                    b.Property<double>("MaxTempAmb")
                        .HasColumnType("REAL");

                    b.Property<double>("MinHumedadAmb")
                        .HasColumnType("REAL");

                    b.Property<double>("MinHumedadSuelo")
                        .HasColumnType("REAL");

                    b.Property<double>("MinTempAmb")
                        .HasColumnType("REAL");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCientifico")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("PlantaId");

                    b.ToTable("Plantas");
                });

            modelBuilder.Entity("Intelligreen.Dominio.PlantaUsuario", b =>
                {
                    b.Property<Guid>("PlantaUsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Apodo")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("DispositivoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("PlantaId")
                        .HasColumnType("TEXT");

                    b.HasKey("PlantaUsuarioId");

                    b.HasIndex("DispositivoId");

                    b.HasIndex("PlantaId");

                    b.ToTable("PlantasUsuarios");
                });

            modelBuilder.Entity("Intelligreen.Dominio.PlantaUsuario", b =>
                {
                    b.HasOne("Intelligreen.Dominio.Dispositivo", "Dispositivo")
                        .WithMany("PlantaUsuarios")
                        .HasForeignKey("DispositivoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Intelligreen.Dominio.Planta", "Planta")
                        .WithMany("PlantaUsuarios")
                        .HasForeignKey("PlantaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Dispositivo");

                    b.Navigation("Planta");
                });

            modelBuilder.Entity("Intelligreen.Dominio.Dispositivo", b =>
                {
                    b.Navigation("PlantaUsuarios");
                });

            modelBuilder.Entity("Intelligreen.Dominio.Planta", b =>
                {
                    b.Navigation("PlantaUsuarios");
                });
#pragma warning restore 612, 618
        }
    }
}
