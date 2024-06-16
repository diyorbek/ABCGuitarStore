using System.ComponentModel.DataAnnotations;

namespace GuitarStore.Models.Product;

public class RentableProduct(
    CategoryEnum categoryEnum,
    string name,
    string description,
    HashSet<string> images,
    GuitarEnum? guitarType,
    HashSet<GuitarEnum>? usedWith,
    float dailyLatePenalty,
    float pricePerRentalDay)
    : Product(categoryEnum, name, description, images, guitarType, usedWith)
{
    [Required]
    [Range(1, 3000, ErrorMessage = "Penalty should be between 1 and 3K")]
    public float DailyLatePenalty { get; set; } = dailyLatePenalty;

    [Required]
    [Range(1, 30000, ErrorMessage = "Price should be between 1 and 30K")]
    public float PricePerRentalDay { get; set; } = pricePerRentalDay;

    public virtual ICollection<RentableItem> RentableItems { get; }

    public static int MaxRentDays { get; set; }
}