﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PetShop.EF.Context;

#nullable disable

namespace PetShop.EF.Migrations
{
    [DbContext(typeof(PetShopContext))]
    partial class PetShopContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PetShop.Model.Customer", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("TIN")
                        .IsRequired()
                        .HasMaxLength(9)
                        .HasColumnType("nvarchar(9)");

                    b.HasKey("ID");

                    b.ToTable("Customer", "PetShop");
                });

            modelBuilder.Entity("PetShop.Model.Employee", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("EmployeeType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<decimal>("SallaryPerMonth")
                        .HasColumnType("decimal(10,2)");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("ID");

                    b.ToTable("Employees", (string)null);
                });

            modelBuilder.Entity("PetShop.Model.Pet", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AnimalType")
                        .HasColumnType("int");

                    b.Property<string>("Breed")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("PetStatus")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ID");

                    b.ToTable("Pets", (string)null);
                });

            modelBuilder.Entity("PetShop.Model.PetFood", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("AnimalType")
                        .HasColumnType("int");

                    b.Property<decimal>("Cost")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ID");

                    b.ToTable("PetFood", (string)null);
                });

            modelBuilder.Entity("PetShop.Model.Transaction", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ID"), 1L, 1);

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeID")
                        .HasColumnType("int");

                    b.Property<int>("PetFoodID")
                        .HasColumnType("int");

                    b.Property<decimal>("PetFoodPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<int>("PetFoodQty")
                        .HasColumnType("int");

                    b.Property<int?>("PetID")
                        .IsRequired()
                        .HasColumnType("int");

                    b.Property<decimal?>("PetPrice")
                        .HasColumnType("decimal(10,2)");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(10,2)");

                    b.HasKey("ID");

                    b.HasIndex("CustomerID");

                    b.HasIndex("EmployeeID");

                    b.HasIndex("PetFoodID");

                    b.HasIndex("PetID")
                        .IsUnique();

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("PetShop.Model.Transaction", b =>
                {
                    b.HasOne("PetShop.Model.Customer", "Customer")
                        .WithMany("Transactions")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PetShop.Model.Employee", "Employee")
                        .WithMany("Transactions")
                        .HasForeignKey("EmployeeID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("PetShop.Model.PetFood", "PetFood")
                        .WithMany("Transactions")
                        .HasForeignKey("PetFoodID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PetShop.Model.Pet", "Pet")
                        .WithOne("Transaction")
                        .HasForeignKey("PetShop.Model.Transaction", "PetID")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Customer");

                    b.Navigation("Employee");

                    b.Navigation("Pet");

                    b.Navigation("PetFood");
                });

            modelBuilder.Entity("PetShop.Model.Customer", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("PetShop.Model.Employee", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("PetShop.Model.Pet", b =>
                {
                    b.Navigation("Transaction")
                        .IsRequired();
                });

            modelBuilder.Entity("PetShop.Model.PetFood", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
