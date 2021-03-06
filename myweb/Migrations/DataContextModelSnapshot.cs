﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using myweb;

namespace myweb.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.8")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("myweb.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ProductID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            Description = "a perfect chair for the office",
                            Image = "chair.jpg",
                            Price = 200,
                            ProductName = "Chair",
                            Quantity = 1
                        },
                        new
                        {
                            ProductID = 2,
                            Description = "Almost new laptop with 8gb ram and 250 ssd hard drive",
                            Image = "laptop.jpg",
                            Price = 2000,
                            ProductName = "Acer Laptop",
                            Quantity = 1
                        },
                        new
                        {
                            ProductID = 3,
                            Description = "Brand new ",
                            Image = "game.jpg",
                            Price = 300,
                            ProductName = "Call of duty",
                            Quantity = 3
                        },
                        new
                        {
                            ProductID = 4,
                            Description = "Brand new bicycle with 7 gears ",
                            Image = "bicycle.jpg",
                            Price = 1200,
                            ProductName = "Bicycle",
                            Quantity = 1
                        },
                        new
                        {
                            ProductID = 5,
                            Description = "New shoes size 42 ",
                            Image = "shoes.jpeg",
                            Price = 200,
                            ProductName = "Shoes",
                            Quantity = 2
                        },
                        new
                        {
                            ProductID = 6,
                            Description = "Used one year but still funtional ",
                            Image = "iphone.jpg",
                            Price = 1300,
                            ProductName = "Iphone 5",
                            Quantity = 1
                        });
                });

            modelBuilder.Entity("myweb.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("UserId");

                    b.ToTable("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
