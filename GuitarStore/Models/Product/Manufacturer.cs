using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuitarStore.Contexts;

namespace GuitarStore.Models.Product;

public class Manufacturer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required] [Length(1, 255)] public string Name { get; set; }
    [Required] [Length(1, 255)] public string Country { get; set; }
    [Length(1, 1000)] public string Description { get; set; }

    public virtual ICollection<ProductManufacturer> ProductManufacturers { get; set; }

    public static Manufacturer? FindByName(AppDbContext context, string name)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (string.IsNullOrEmpty(name)) throw new ArgumentException("Name cannot be null or empty", nameof(name));

        return context.Manufacturers.SingleOrDefault(a => a.Name == name);
    }
}