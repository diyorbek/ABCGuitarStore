using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Models.Product;

public class ProductManufacturer
{
    [Key] public Guid ProductId { get; set; }
    [Key] public Guid ManufacturerId { get; set; }

    [ForeignKey("ProductId")] public virtual Product Product { get; set; }
    [ForeignKey("ManufacturerId")] public virtual Manufacturer Manufacturer { get; set; }
}