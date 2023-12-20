﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_Medii_Programare.Data;

#nullable disable

namespace Proiect_Medii_Programare.Migrations
{
    [DbContext(typeof(Proiect_Medii_ProgramareContext))]
    [Migration("20231215153749_membrii")]
    partial class membrii
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.23")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Proiect_Medii_Programare.Models.Cameră", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Descriere")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("PrețPeNoapte")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("TipCameră")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Cameră");
                });

            modelBuilder.Entity("Proiect_Medii_Programare.Models.Membru", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Adresă")
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Nume")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Prenume")
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Telefon")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Membru");
                });

            modelBuilder.Entity("Proiect_Medii_Programare.Models.Rezervare", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<DateTime>("Ajunge")
                        .HasColumnType("datetime2");

                    b.Property<string>("Animal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CamerăID")
                        .HasColumnType("int");

                    b.Property<string>("Comentarii")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("Pleacă")
                        .HasColumnType("datetime2");

                    b.Property<int?>("ServiciuID")
                        .HasColumnType("int");

                    b.Property<int?>("SpecieID")
                        .HasColumnType("int");

                    b.Property<string>("Stăpân")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.HasIndex("CamerăID");

                    b.HasIndex("SpecieID");

                    b.ToTable("Rezervare");
                });

            modelBuilder.Entity("Proiect_Medii_Programare.Models.Serviciu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<decimal>("PrețServiciu")
                        .HasColumnType("decimal(6,2)");

                    b.Property<string>("ServiciiSuplimentare")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Serviciu");
                });

            modelBuilder.Entity("Proiect_Medii_Programare.Models.Specie", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("SpecieAnimal")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID");

                    b.ToTable("Specie");
                });

            modelBuilder.Entity("RezervareServiciu", b =>
                {
                    b.Property<int>("RezervăriID")
                        .HasColumnType("int");

                    b.Property<int>("ServiciiID")
                        .HasColumnType("int");

                    b.HasKey("RezervăriID", "ServiciiID");

                    b.HasIndex("ServiciiID");

                    b.ToTable("RezervareServiciu");
                });

            modelBuilder.Entity("Proiect_Medii_Programare.Models.Rezervare", b =>
                {
                    b.HasOne("Proiect_Medii_Programare.Models.Cameră", "Cameră")
                        .WithMany("Rezervări")
                        .HasForeignKey("CamerăID");

                    b.HasOne("Proiect_Medii_Programare.Models.Specie", "Specie")
                        .WithMany("Rezervări")
                        .HasForeignKey("SpecieID");

                    b.Navigation("Cameră");

                    b.Navigation("Specie");
                });

            modelBuilder.Entity("RezervareServiciu", b =>
                {
                    b.HasOne("Proiect_Medii_Programare.Models.Rezervare", null)
                        .WithMany()
                        .HasForeignKey("RezervăriID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Proiect_Medii_Programare.Models.Serviciu", null)
                        .WithMany()
                        .HasForeignKey("ServiciiID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Proiect_Medii_Programare.Models.Cameră", b =>
                {
                    b.Navigation("Rezervări");
                });

            modelBuilder.Entity("Proiect_Medii_Programare.Models.Specie", b =>
                {
                    b.Navigation("Rezervări");
                });
#pragma warning restore 612, 618
        }
    }
}
