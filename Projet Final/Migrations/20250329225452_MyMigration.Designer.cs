﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Projet_Final.Data;

#nullable disable

namespace Projet_Final.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20250329225452_MyMigration")]
    partial class MyMigration
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Projet_Final.Models.Furniture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Comments")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnType("nvarchar(255)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("TypeFurnitureId")
                        .HasColumnType("int");

                    b.Property<string>("UrlPicture")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TypeFurnitureId");

                    b.ToTable("Furnitures");
                });

            modelBuilder.Entity("Projet_Final.Models.FurnitureType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("FurnitureTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Personnalisés"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Tables"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Portes"
                        },
                        new
                        {
                            Id = 4,
                            Name = "Armoires"
                        },
                        new
                        {
                            Id = 5,
                            Name = "Chaises"
                        },
                        new
                        {
                            Id = 6,
                            Name = "Frises"
                        },
                        new
                        {
                            Id = 7,
                            Name = "Sculptures"
                        });
                });

            modelBuilder.Entity("Projet_Final.Models.Furniture", b =>
                {
                    b.HasOne("Projet_Final.Models.FurnitureType", "TypeFurniture")
                        .WithMany("Furnitures")
                        .HasForeignKey("TypeFurnitureId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TypeFurniture");
                });

            modelBuilder.Entity("Projet_Final.Models.FurnitureType", b =>
                {
                    b.Navigation("Furnitures");
                });
#pragma warning restore 612, 618
        }
    }
}
