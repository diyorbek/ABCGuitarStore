﻿// <auto-generated />
using System;
using GuitarStore.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace GuitarStore.Migrations
{
    [DbContext(typeof(AppDbContext))]
    partial class AppDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.6");

            modelBuilder.Entity("CustomerOrder", b =>
                {
                    b.Property<Guid>("CustomersId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrdersOrderId")
                        .HasColumnType("TEXT");

                    b.HasKey("CustomersId", "OrdersOrderId");

                    b.HasIndex("OrdersOrderId");

                    b.ToTable("CustomerOrder", (string)null);
                });

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

            modelBuilder.Entity("GuitarStore.Models.Product.Order", b =>
                {
                    b.Property<Guid>("OrderId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("OrderDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("OrderStatus")
                        .HasColumnType("INTEGER");

                    b.HasKey("OrderId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.OrderItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("OrderId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Quantity")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("SellableProductId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("OrderId");

                    b.HasIndex("SellableProductId");

                    b.ToTable("OrderItems");
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

            modelBuilder.Entity("GuitarStore.Models.Product.ProductStore", b =>
                {
                    b.Property<Guid>("ProductId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("TEXT");

                    b.HasKey("ProductId", "StoreId");

                    b.HasIndex("StoreId");

                    b.ToTable("ProductStores");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.Rent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("ActualEndDate")
                        .HasColumnType("TEXT");

                    b.Property<int>("RentStatus")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("RentableItemId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("ScheduledEndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("TrustedCustomerId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RentableItemId");

                    b.HasIndex("TrustedCustomerId");

                    b.ToTable("Rent");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.RentableItem", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("ItemCode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<Guid>("RentableProductId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RentableProductId");

                    b.ToTable("RentableItems");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.Store", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Stores");
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

                    b.Property<int?>("CommissionRate")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ContractNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Positions")
                        .HasColumnType("INTEGER");

                    b.Property<int?>("PrivilegeLevel")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("StoreId")
                        .HasColumnType("TEXT");

                    b.HasIndex("StoreId");

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

            modelBuilder.Entity("CustomerOrder", b =>
                {
                    b.HasOne("GuitarStore.Models.Customer", null)
                        .WithMany()
                        .HasForeignKey("CustomersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuitarStore.Models.Product.Order", null)
                        .WithMany()
                        .HasForeignKey("OrdersOrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("GuitarStore.Models.Product.OrderItem", b =>
                {
                    b.HasOne("GuitarStore.Models.Product.Order", "Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuitarStore.Models.Product.SellableProduct", "SellableProduct")
                        .WithMany("OrderItems")
                        .HasForeignKey("SellableProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("SellableProduct");
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

            modelBuilder.Entity("GuitarStore.Models.Product.ProductStore", b =>
                {
                    b.HasOne("GuitarStore.Models.Product.Product", "Product")
                        .WithMany("ProductStores")
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuitarStore.Models.Product.Store", "Store")
                        .WithMany("ProductStores")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Product");

                    b.Navigation("Store");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.Rent", b =>
                {
                    b.HasOne("GuitarStore.Models.Product.RentableItem", "RentableItem")
                        .WithMany("Rents")
                        .HasForeignKey("RentableItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("GuitarStore.Models.TrustedCustomer", "TrustedCustomer")
                        .WithMany("Rents")
                        .HasForeignKey("TrustedCustomerId");

                    b.Navigation("RentableItem");

                    b.Navigation("TrustedCustomer");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.RentableItem", b =>
                {
                    b.HasOne("GuitarStore.Models.Product.RentableProduct", "RentableProduct")
                        .WithMany("RentableItems")
                        .HasForeignKey("RentableProductId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RentableProduct");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.Store", b =>
                {
                    b.OwnsOne("GuitarStore.Models.Product.Address", "Address", b1 =>
                        {
                            b1.Property<Guid>("StoreId")
                                .HasColumnType("TEXT");

                            b1.Property<string>("City")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("PostalCode")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.Property<string>("Street")
                                .IsRequired()
                                .HasColumnType("TEXT");

                            b1.HasKey("StoreId");

                            b1.ToTable("Stores");

                            b1.WithOwner()
                                .HasForeignKey("StoreId");
                        });

                    b.Navigation("Address")
                        .IsRequired();
                });

            modelBuilder.Entity("GuitarStore.Models.Employee", b =>
                {
                    b.HasOne("GuitarStore.Models.Product.Store", "Store")
                        .WithMany("Employees")
                        .HasForeignKey("StoreId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Store");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.Manufacturer", b =>
                {
                    b.Navigation("ProductManufacturers");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.Order", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.Product", b =>
                {
                    b.Navigation("ProductManufacturers");

                    b.Navigation("ProductStores");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.RentableItem", b =>
                {
                    b.Navigation("Rents");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.Store", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("ProductStores");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.RentableProduct", b =>
                {
                    b.Navigation("RentableItems");
                });

            modelBuilder.Entity("GuitarStore.Models.Product.SellableProduct", b =>
                {
                    b.Navigation("OrderItems");
                });

            modelBuilder.Entity("GuitarStore.Models.TrustedCustomer", b =>
                {
                    b.Navigation("Rents");
                });
#pragma warning restore 612, 618
        }
    }
}
