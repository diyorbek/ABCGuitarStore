using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Models.Product;

public class ProductStore
{
    [Range(0, 100)] public int Quantity { get; set; }

    // Relational members
    [Key] public Guid ProductId { get; init; }
    [Key] public Guid StoreId { get; init; }
    [ForeignKey("ProductId")] public virtual Product Product { get; init; }
    [ForeignKey("StoreId")] public virtual Store Store { get; init; }
}