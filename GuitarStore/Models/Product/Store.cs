using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using GuitarStore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GuitarStore.Models.Product;

public class Store
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required] [Length(1, 255)] public string Name { get; set; }
    [Required] public Address Address { get; set; } // Complex attribute

    public virtual ICollection<ProductStore> ProductStores { get; set; }

    public static List<Store> FindByCity(AppDbContext context, string city)
    {
        ArgumentNullException.ThrowIfNull(context);

        if (string.IsNullOrEmpty(city)) throw new ArgumentException("City cannot be null or empty", nameof(city));

        return context.Stores.Where(a => a.Address.City == city).ToList();
    }
}

[Owned]
public class Address
{
    [Required] [Length(1, 255)] public string Street { get; set; }
    [Required] [Length(1, 255)] public string City { get; set; }
    [Required] [Length(1, 255)] public string PostalCode { get; set; }
}