using GuitarStore.Models;
using GuitarStore.Models.Product;
using Microsoft.EntityFrameworkCore;

namespace GuitarStore.Contexts;

public class AppDbContext : DbContext
{
    private readonly string _connectionString;

    public AppDbContext(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public AppDbContext(IConfiguration configuration, DbContextOptions options) : base(options)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection")!;
    }

    public DbSet<Account> Accounts { get; set; } // DbSet of the base class
    public DbSet<Product> Products { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<ProductManufacturer> ProductManufacturers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure Account
        modelBuilder.Entity<Account>().HasKey(a => a.Id);

        // Configure Employee
        modelBuilder.Entity<Employee>().HasBaseType<Account>();

        // Configure Customer (abstract base class)
        modelBuilder.Entity<Customer>().HasBaseType<Account>();

        // Configure RegularCustomer
        modelBuilder.Entity<RegularCustomer>().HasBaseType<Customer>();

        // Configure TrustedCustomer
        modelBuilder.Entity<TrustedCustomer>().HasBaseType<Customer>();

        // Discriminator for Customer types
        modelBuilder.Entity<Customer>()
            .HasDiscriminator<string>("CustomerType")
            .HasValue<RegularCustomer>("Regular")
            .HasValue<TrustedCustomer>("Trusted");

        modelBuilder.Entity<Account>()
            .HasIndex(p => p.Email)
            .IsUnique();
        
        modelBuilder.Entity<Product>()
            .HasDiscriminator<string>("ProductType")
            .HasValue<RentableProduct>("Rentable")
            .HasValue<SellableProduct>("Sellable");

        modelBuilder.Entity<ProductManufacturer>()
            .HasKey(pm => new { pm.ProductId, pm.ManufacturerId });

        modelBuilder.Entity<ProductManufacturer>()
            .HasOne(pm => pm.Product)
            .WithMany(p => p.ProductManufacturers)
            .HasForeignKey(pm => pm.ProductId);

        modelBuilder.Entity<ProductManufacturer>()
            .HasOne(pm => pm.Manufacturer)
            .WithMany(m => m.ProductManufacturers)
            .HasForeignKey(pm => pm.ManufacturerId);
    }
}