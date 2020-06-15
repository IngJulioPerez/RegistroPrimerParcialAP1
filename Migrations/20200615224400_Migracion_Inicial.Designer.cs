﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RegistroPrimerParcialAP1.DAL;

namespace RegistroPrimerParcialAP1.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20200615224400_Migracion_Inicial")]
    partial class Migracion_Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.5");

            modelBuilder.Entity("RegistroPrimerParcialAP1.Entidades.Articulos", b =>
                {
                    b.Property<int>("ProductoID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<float>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencia")
                        .HasColumnType("INTEGER");

                    b.Property<float>("ValorInventario")
                        .HasColumnType("REAL");

                    b.HasKey("ProductoID");

                    b.ToTable("Articulos");
                });
#pragma warning restore 612, 618
        }
    }
}