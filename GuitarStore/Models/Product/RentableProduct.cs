using System.ComponentModel.DataAnnotations;
using GuitarStore.Services;

namespace GuitarStore.Models.Product;

public class RentableProduct : Product
{
    // static member control
    private static StaticFieldsService _staticFieldsService;

    public RentableProduct()
    {
    }

    public RentableProduct(
        CategoryEnum categoryEnum,
        string name,
        string description,
        List<string> images,
        GuitarEnum? guitarType,
        List<GuitarEnum>? usedWith,
        float dailyLatePenalty,
        float pricePerRentalDay) : base(categoryEnum, name, description, images, guitarType, usedWith)
    {
        DailyLatePenalty = dailyLatePenalty;
        PricePerRentalDay = pricePerRentalDay;
    }

    [Required]
    [Range(1, 3000, ErrorMessage = "Penalty should be between 1 and 3K")]
    public float DailyLatePenalty { get; set; }

    [Required]
    [Range(1, 30000, ErrorMessage = "Price should be between 1 and 30K")]
    public float PricePerRentalDay { get; set; }

    public virtual ICollection<RentableItem> RentableItems { get; }

    public static int MaxRentDays
    {
        get => _staticFieldsService.ClassAttributes.MaxRentDays;
        set => _staticFieldsService.ClassAttributes.MaxRentDays = value;
    }

    public static void InitializeStaticMembersService(StaticFieldsService svc)
    {
        _staticFieldsService = svc;
    }
}