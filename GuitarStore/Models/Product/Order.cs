using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GuitarStore.Models.Product;

public enum OrderStatus
{
    PENDING,
    READY_FOR_PICKUP,
    COMPLETED,
    CANCELLED
}

public class Order
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid OrderId { get; init; }

    [Required] public DateTime OrderDate { get; init; } = DateTime.Now;
    [Required] public OrderStatus OrderStatus { get; set; } = OrderStatus.PENDING;

    public virtual Customer Customer { get; init; }
    public virtual ICollection<OrderItem> OrderItems { get; init; }

    public float getRetailPrice()
    {
        return OrderItems.Sum(item => item.SellableProduct.Price * item.Quantity);
    }
}