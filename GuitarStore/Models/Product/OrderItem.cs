using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Models.Product;

public class OrderItem
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }

    [Required] public int Quantity { get; set; }

    [Required] public Guid OrderId { get; set; }
    [Required] public Guid SellableProductId { get; set; }
    [ForeignKey("OrderId")] public Order Order { get; set; }
    [ForeignKey("SellableProductId")] public SellableProduct SellableProduct { get; set; }
}