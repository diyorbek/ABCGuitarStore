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
    public Guid OrderId { get; set; }

    [Required] public DateTime OrderDate { get; set; } = DateTime.Now;
    [Required] public OrderStatus OrderStatus { get; set; } = OrderStatus.PENDING;

    public virtual ICollection<Customer> Customers { get; set; }
    public virtual ICollection<OrderItem> OrderItems { get; set; }

    public float getRetailPrice()
    {
        return OrderItems.Sum(item => item.SellableProduct.Price * item.Quantity);
    }
}