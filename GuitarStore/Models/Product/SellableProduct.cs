using System.ComponentModel.DataAnnotations;

namespace GuitarStore.Models.Product;

public class SellableProduct(
    CategoryEnum categoryEnum,
    string name,
    string description,
    HashSet<string> images,
    GuitarEnum? guitarType,
    HashSet<GuitarEnum>? usedWith,
    float price,
    bool isUsed)
    : Product(categoryEnum, name, description, images,
        guitarType, usedWith)
{
    [Required]
    [Range(1, 30000, ErrorMessage = "Price should be between 1 and 30K")]
    public float Price { get; set; } = price;

    [Required] public bool IsUsed { get; set; } = isUsed;

    public virtual ICollection<OrderItem> OrderItems { get; set; }
}