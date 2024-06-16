﻿// <auto-generated />
using System;
using GuitarStore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuitarStore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    [Migration("20240616095948_CreateProductManufacturerRelationship")]
    partial class CreateProductManufacturerRelationship
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("GuitarStore.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("CustomerType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.ToTable("Accounts");

                    b.HasDiscriminator<string>("CustomerType").HasValue("Account");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("GuitarStore.Models.Product.Manufacturer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Manufacturers");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<int>("CategoryEnum")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int?>("GuitarType")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Images")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ProductType")
                        .IsRequired()
                        .HasMaxLength(8)
                        .HasColumnType("TEXT");

                    b.Property<string>("UsedWith")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasDiscriminator<string>("ProductType").HasValue("Product");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("GuitarStore.Models.Product.ProductManufacturer", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("ManufacturerId")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId", "ManufacturerId");

                    b.HasIndex("ManufacturerId");

                    b.ToTable("ProductManufacturers");
                });

            modelBuilder.Entity("GuitarStore.Models.Customer", b =>
                {
                    b.HasBaseType("GuitarStore.Models.Account");

                    b.Property<DateTime>("Birthdate")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Customer");
                });

            modelBuilder.Entity("GuitarStore.Models.Employee", b =>
                {
                    b.HasBaseType("GuitarStore.Models.Account");

                    b.Property<int>("CommissionRate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContractNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Positions")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PrivilegeLevel")
                        .HasColumnType("INTEGER");

                    b.HasDiscriminator().HasValue("Employee");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.RentableProduct", b =>
                {
                    b.HasBaseType("GuitarStore.Models.Product.Product");

                    b.Property<float>("DailyLatePenalty")
                        .HasColumnType("REAL");

                    b.Property<float>("PricePerRentalDay")
                        .HasColumnType("REAL");

                    b.HasDiscriminator().HasValue("Rentable");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.SellableProduct", b =>
                {
                    b.HasBaseType("GuitarStore.Models.Product.Product");

                    b.Property<bool>("IsUsed")
                        .HasColumnType("INTEGER");

                    b.Property<float>("Price")
                        .HasColumnType("REAL");

                    b.HasDiscriminator().HasValue("Sellable");
                });

            modelBuilder.Entity("GuitarStore.Models.RegularCustomer", b =>
                {
                    b.HasBaseType("GuitarStore.Models.Customer");

                    b.HasDiscriminator().HasValue("Regular");
                });

            modelBuilder.Entity("GuitarStore.Models.TrustedCustomer", b =>
                {
                    b.HasBaseType("GuitarStore.Models.Customer");

                    b.Property<DateTime>("StatusExpiryDate")
                        .HasColumnType("TEXT");

                    b.HasDiscriminator().HasValue("Trusted");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.ProductManufacturer", b =>
                {
                    b.HasOne("GuitarStore.Models.Product.Manufacturer", "Manufacturer")
                        .WithMany("ProductManufacturers")
                        .HasForeignKey("ManufacturerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuitarStore.Models.Product.Product", "Product")
                        .WithMany("ProductManufacturers")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manufacturer");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.Manufacturer", b =>
                {
                    b.Navigation("ProductManufacturers");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.Product", b =>
                {
                    b.Navigation("ProductManufacturers");
                });
#pragma warning restore 612, 618
        }
    }
}
