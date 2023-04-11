﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WebApplication1.AppDbContext;

#nullable disable

namespace WebApplication1.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("WebApplication1.Models.Categoria", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataCriação")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Editado")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EditadoPor")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("WebApplication1.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("CriadoPor")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<DateTime>("DataCriação")
                        .HasColumnType("datetime(6)");

                    b.Property<DateTime?>("Editado")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("EditadoPor")
                        .HasColumnType("longtext");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("longtext");

                    b.Property<int>("TipoId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TipoId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("WebApplication1.Models.Usuario", b =>
                {
                    b.HasOne("WebApplication1.Models.Categoria", "Tipo")
                        .WithMany()
                        .HasForeignKey("TipoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Tipo");
                });
#pragma warning restore 612, 618
        }
    }
}
