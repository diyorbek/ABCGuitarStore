using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuitarStore.Contexts;

namespace GuitarStore.Models.Product;

public class Manufacturer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Required] [Length(1, 255)] public string Name { get; set; }
    [Required] [Length(1, 255)] public string Country { get; set; }
    [Length(1, 1000)] public string? Description { get; set; }

    // Relational collection
    public virtual ICollection<Product> Products { get; init; }

    // Methods
    public List<Product> GetProducts()
    {
        return Products.OrderBy(p => p.Name).ToList();
    }

    public void AddProduct(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        Products.Add(product);
    }

    public void RemoveProduct(Product product)
    {
        ArgumentNullException.ThrowIfNull(product);

        Products.Remove(product);
    }

    public static Manufacturer? FindByName(AppDbContext context, string name)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name cannot be null or empty", nameof(name));

        return context.Manufacturers.SingleOrDefault(a => a.Name == name);
    }
}