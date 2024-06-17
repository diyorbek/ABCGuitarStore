using System.ComponentModel.DataAnnotations;

namespace GuitarStore.Models.Product;

public class SellableProduct : Product
{
    public SellableProduct(
        CategoryEnum categoryEnum,
        string name,
        string description,
        List<string> images,
        GuitarEnum? guitarType,
        List<GuitarEnum>? usedWith,
        float price,
        bool isUsed) : base(categoryEnum, name, description, images,
        guitarType, usedWith)
    {
        Price = price;
        IsUsed = isUsed;
    }

    // Used for seeding
    public SellableProduct()
    {
        Price = 0;
        IsUsed = false;
    }

    [Required]
    [Range(1, 30000, ErrorMessage = "Price should be between 1 and 30K")]
    public float Price { get; set; }

    [Required] public bool IsUsed { get; set; }

    public virtual ICollection<OrderItem> OrderItems { get; set; }
}