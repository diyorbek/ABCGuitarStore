using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
using GuitarStore.Contexts;
using Microsoft.EntityFrameworkCore;

namespace GuitarStore.Models.Product;

public class Store
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; init; }

    [Required] [Length(1, 255)] public string Name { get; set; }
    [Required] public Address Address { get; set; } // Complex attribute
    [Required] public string Image { get; set; }

    // Relational collection
    [JsonIgnore] public virtual ICollection<ProductStore> ProductStores { get; init; }
    [JsonIgnore] public virtual ICollection<Employee> Employees { get; init; }

    // Methods
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
    [Required] [Length(1, 255)] public string Street { get; init; }
    [Required] [Length(1, 255)] public string City { get; init; }
    [Required] [Length(1, 255)] public string PostalCode { get; init; }
}