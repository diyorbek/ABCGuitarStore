using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Models.Product;

public class OrderItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required] public int Quantity { get; set; }

    // Relational memebers
    [Required] public Guid OrderId { get; init; }
    [Required] public Guid SellableProductId { get; init; }
    [ForeignKey("OrderId")] public Order Order { get; init; }
    [ForeignKey("SellableProductId")] public SellableProduct SellableProduct { get; init; }
}