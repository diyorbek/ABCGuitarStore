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

    public DbSet<ClassAttributes?> ClassAttributes { get; set; }

    public DbSet<Account> Accounts { get; set; }
    public DbSet<Product> Products { get; set; }
    public DbSet<SellableProduct> SellableProduct { get; set; }
    public DbSet<Manufacturer> Manufacturers { get; set; }
    public DbSet<Store> Stores { get; set; }
    public DbSet<ProductStore> ProductStores { get; set; }
    public DbSet<RentableProduct> RentableProducts { get; set; }
    public DbSet<RentableItem> RentableItems { get; set; }
    public DbSet<Order> Orders { get; set; }
    public DbSet<OrderItem> OrderItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Config static members
        modelBuilder.Entity<ClassAttributes>().HasData(new ClassAttributes { Id = Guid.NewGuid() });

        // Configure Account
        modelBuilder.Entity<Account>().HasKey(a => a.Id);
        modelBuilder.Entity<Employee>().HasBaseType<Account>();
        modelBuilder.Entity<Customer>().HasBaseType<Account>();
        modelBuilder.Entity<RegularCustomer>().HasBaseType<Customer>();
        modelBuilder.Entity<TrustedCustomer>().HasBaseType<Customer>();

        // Discriminator for Customer types
        modelBuilder.Entity<Customer>()
            .HasDiscriminator<string>("CustomerType")
            .HasValue<RegularCustomer>("Regular")
            .HasValue<TrustedCustomer>("Trusted");

        modelBuilder.Entity<Account>()
            .HasIndex(p => p.Email)
            .IsUnique();

        // Product and Manufacturer configs
        modelBuilder.Entity<Product>()
            .HasDiscriminator<string>("ProductType")
            .HasValue<RentableProduct>("Rentable")
            .HasValue<SellableProduct>("Sellable");

        modelBuilder.Entity<Product>()
            .HasMany(p => p.Manufacturers)
            .WithMany(m => m.Products);

        // modelBuilder.Entity<ProductManufacturer>()
        //     .HasKey(pm => new { pm.ProductId, pm.ManufacturerId });
        //
        // modelBuilder.Entity<ProductManufacturer>()
        //     .HasOne(pm => pm.Product)
        //     .WithMany(p => p.ProductManufacturers)
        //     .HasForeignKey(pm => pm.ProductId);
        //
        // modelBuilder.Entity<ProductManufacturer>()
        //     .HasOne(pm => pm.Manufacturer)
        //     .WithMany(m => m.ProductManufacturers)
        //     .HasForeignKey(pm => pm.ManufacturerId);

        // Store configs
        modelBuilder.Entity<Store>().OwnsOne(s => s.Address);

        modelBuilder.Entity<ProductStore>()
            .HasKey(ps => new { ps.ProductId, ps.StoreId });

        modelBuilder.Entity<ProductStore>()
            .HasOne(ps => ps.Product)
            .WithMany(p => p.ProductStores)
            .HasForeignKey(ps => ps.ProductId);

        modelBuilder.Entity<ProductStore>()
            .HasOne(ps => ps.Store)
            .WithMany(s => s.ProductStores)
            .HasForeignKey(ps => ps.StoreId);

        // Store employee configs
        modelBuilder.Entity<Employee>()
            .HasOne(e => e.Store)
            .WithMany(s => s.Employees)
            .HasForeignKey(e => e.StoreId);

        // RentableItem config
        modelBuilder.Entity<RentableProduct>()
            .HasMany(rp => rp.RentableItems)
            .WithOne(ri => ri.RentableProduct)
            .HasForeignKey(ri => ri.RentableProductId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete RentableItems

        // Rent config
        modelBuilder.Entity<RentableItem>()
            .HasMany(ri => ri.Rents)
            .WithOne(r => r.RentableItem)
            .HasForeignKey(r => r.RentableItemId)
            .OnDelete(DeleteBehavior.Cascade); // Cascade delete Rents

        modelBuilder.Entity<TrustedCustomer>()
            .HasMany(r => r.Rents)
            .WithOne(tc => tc.TrustedCustomer)
            .HasForeignKey(r => r.TrustedCustomerId);
        // .OnDelete(DeleteBehavior.Cascade);

        // Order config
        modelBuilder.Entity<Customer>()
            .HasMany(c => c.Orders)
            .WithOne(o => o.Customer);

        modelBuilder.Entity<Order>()
            .HasMany(o => o.OrderItems)
            .WithOne(oi => oi.Order)
            .HasForeignKey(oi => oi.OrderId);

        modelBuilder.Entity<OrderItem>()
            .HasOne(oi => oi.SellableProduct)
            .WithMany(sp => sp.OrderItems)
            .HasForeignKey(oi => oi.SellableProductId);
    }
}