﻿// <auto-generated />
using System;
using Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Datos.Migrations
{
    [DbContext(typeof(ParcialContext))]
    [Migration("20201024153347_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .UseIdentityColumns()
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.0-rc.2.20475.6");

            modelBuilder.Entity("Entidad.Ayuda", b =>
                {
                    b.Property<string>("personaIdentificacion")
                        .HasColumnType("varchar(11)");

                    b.Property<string>("Ciudad")
                        .HasColumnType("varchar(15)");

                    b.Property<string>("Departamento")
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("Date");

                    b.Property<string>("Modalidad")
                        .HasColumnType("varchar(15)");

                    b.Property<decimal>("Valor")
                        .HasColumnType("decimal(11)");

                    b.HasKey("personaIdentificacion");

                    b.ToTable("Ayudas");
                });

            modelBuilder.Entity("Entidad.Persona", b =>
                {
                    b.Property<string>("Identificacion")
                        .HasColumnType("varchar(11)");

                    b.Property<int>("Edad")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .HasColumnType("varchar(20)");

                    b.Property<string>("Sexo")
                        .HasColumnType("varchar(11)");

                    b.HasKey("Identificacion");

                    b.ToTable("Personas");
                });
#pragma warning restore 612, 618
        }
    }
}