using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Models.Product;

public class ProductStore
{
    [Key] public Guid ProductId { get; set; }
    [Key] public Guid StoreId { get; set; }

    [Range(0, 100)] public int Quantity { get; set; }

    [ForeignKey("ProductId")] public virtual Product Product { get; set; }
    [ForeignKey("StoreId")] public virtual Store Store { get; set; }
}